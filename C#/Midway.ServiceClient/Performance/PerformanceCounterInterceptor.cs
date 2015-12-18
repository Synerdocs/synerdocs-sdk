using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace Midway.ServiceClient
{
    public class PerformanceCounterInterceptor : IClientMessageInspector
    {
        private const string MidwayClientCategoryName = "Midway Client";
        private PerOperationCounter totalOperations;
        private PerOperationCounter totalOperationsSuccess;
        private PerOperationCounter totalOperationsFault;
        private PerOperationCounter operationsPerSecond;
        private PerOperationCounter operationsStartedPerSecond;
        private PerOperationCounter averageDuration;
        private PerOperationCounter averageDurationBase;
        private PerOperationCounter totalOperationsExecuting;

        private readonly string[] operations;

        public PerformanceCounterInterceptor(string [] operations)
        {
            this.operations = operations;
            SetupCounters();
        }

        private void CreateIfNotExists(IEnumerable<CounterCreationData> totalCounterCreationDatas)
        {

            // размножаем счетчики по именам операций
            var multipliedBtOperations = operations
                .SelectMany(op => totalCounterCreationDatas.Select(ccd => new CounterCreationData()
                    {
                        CounterHelp = ccd.CounterHelp,
                        CounterName = PerOperationCounter.CounterNameForOperation(ccd.CounterName, op), 
                        CounterType = ccd.CounterType
                    })).Union(totalCounterCreationDatas).ToArray();

            // если ес ть хотя бы один не зарегистрированный счетчик
            if (!PerformanceCounterCategory.Exists(MidwayClientCategoryName) || multipliedBtOperations.Any(
                    d => !PerformanceCounterCategory.CounterExists(d.CounterName, MidwayClientCategoryName)))
            {
                // удаляем категорию и регистрируем сноваt
                if (PerformanceCounterCategory.Exists(MidwayClientCategoryName))
                    PerformanceCounterCategory.Delete(MidwayClientCategoryName);

                var counterCreationDataCollection = new CounterCreationDataCollection(multipliedBtOperations.ToArray());

                PerformanceCounterCategory.Create(MidwayClientCategoryName,
                                                  "Счетчики производительности веб-сервиса обмена",
                                                  PerformanceCounterCategoryType.SingleInstance,
                                                  counterCreationDataCollection);
            }
        }

        class PerOperationCounter
        {
            private readonly PerformanceCounter totalCounter;
            private readonly Dictionary<string, PerformanceCounter> operationCouners;

            public static string CounterNameForOperation(string counterName, string opration)
            {
                const string baseSuffix = " base";
                string suffix = "";
                if (counterName.EndsWith(baseSuffix))
                {
                    counterName = counterName.Substring(0, counterName.Length - baseSuffix.Length);
                    suffix = baseSuffix;
                }
                var counterNameForOperation = string.Format("{0}_{1}{2}", counterName, opration, suffix);
                return counterNameForOperation;
            }

            public PerOperationCounter(string counterName, IEnumerable<string> operations)
            {
                totalCounter = new PerformanceCounter
                                   {
                                       CategoryName = MidwayClientCategoryName,
                                       CounterName = counterName,
                                       MachineName = ".",
                                       ReadOnly = false,
                                   };
                operationCouners = operations.ToDictionary(op => op, op => new PerformanceCounter
                    {
                        CategoryName = MidwayClientCategoryName,
                        CounterName = CounterNameForOperation(counterName, op),
                        MachineName = ".",
                        ReadOnly = false,
                    });
            }

            public static string OperationName(Message message)
            {
                var action = message.Headers.Action;
                var operationName = action.Substring(action.LastIndexOf("/", StringComparison.OrdinalIgnoreCase) + 1);
                return operationName;
            }


            public long RawValue
            {
                set
                {
                    totalCounter.RawValue = value;
                    foreach (var performanceCounter in operationCouners.Values)
                    {
                        performanceCounter.RawValue = value;
                    }
                }
            }

            public void Increment(string operation)
            {
                totalCounter.Increment();
                this.operationCouners[operation].Increment();
            }

            public void IncrementBy(string operation, long ticks)
            {
                totalCounter.IncrementBy(ticks);
                this.operationCouners[operation].IncrementBy(ticks);
            }

            public void Decrement(string operation)
            {
                totalCounter.Decrement();
                this.operationCouners[operation].Decrement();
            }
        }

        private void SetupCounters()
        {
            const string totalOpsName = "# operations executed";
            const string totalOpsSuccessName = "# operations success executed";
            const string totalOpsFaultName = "# operations fault executed";
            const string opsPerSecondName = "# operations / sec";
            const string opsStartedPerSecondName = "# operations started / sec";
            const string avgDurationName = "average time per operation";
            const string avgDurationBaseName = "average time per operation base";
            const string totalExecutingOpsName = "# operations executing";

            CreateIfNotExists(new[]
                                  {
                                      new CounterCreationData
                                          {
                                              CounterName = totalOpsName,
                                              CounterHelp = "Total number of operations executed",
                                              CounterType = PerformanceCounterType.NumberOfItems32
                                          },
                                      new CounterCreationData
                                          {
                                              CounterName = totalOpsSuccessName,
                                              CounterHelp = "Total number of success operations executed",
                                              CounterType = PerformanceCounterType.NumberOfItems32
                                          }
                                      ,
                                      new CounterCreationData
                                          {
                                              CounterName = totalOpsFaultName,
                                              CounterHelp = "Total number of fault operations executed",
                                              CounterType = PerformanceCounterType.NumberOfItems32
                                          },
                                      new CounterCreationData
                                          {
                                              CounterName = opsPerSecondName,
                                              CounterHelp = "Number of operations executed per second",
                                              CounterType = PerformanceCounterType.RateOfCountsPerSecond32
                                          },
                                      new CounterCreationData
                                          {
                                              CounterName = opsStartedPerSecondName,
                                              CounterHelp = "Number of operations started per second",
                                              CounterType = PerformanceCounterType.RateOfCountsPerSecond32
                                          },
                                      new CounterCreationData
                                          {
                                              CounterName = avgDurationName,
                                              CounterHelp = "Average duration per operation execution",
                                              CounterType = PerformanceCounterType.AverageTimer32
                                          },
                                      new CounterCreationData
                                          {
                                              CounterName = avgDurationBaseName,
                                              CounterHelp = "Average duration per operation execution base",
                                              CounterType = PerformanceCounterType.AverageBase
                                          },
                                      new CounterCreationData
                                          {
                                              CounterName = totalExecutingOpsName,
                                              CounterHelp = "Number of execiting operations",
                                              CounterType = PerformanceCounterType.NumberOfItems32
                                          }
                                  });


            //TODO счетчки по операциям, покажет общую карттину в разрезе операций; список операций можно достать из exchangeServiceSoapClient.Endpoint.Contract.Operations
            totalOperations = new PerOperationCounter(totalOpsName, operations);
            totalOperationsSuccess = new PerOperationCounter(totalOpsSuccessName, operations);
            totalOperationsFault = new PerOperationCounter(totalOpsFaultName, operations);
            operationsPerSecond = new PerOperationCounter(opsPerSecondName, operations);
            operationsStartedPerSecond = new PerOperationCounter(opsStartedPerSecondName, operations);
            averageDuration = new PerOperationCounter(avgDurationName, operations);
            averageDurationBase = new PerOperationCounter(avgDurationBaseName, operations);
            totalOperationsExecuting = new PerOperationCounter(totalExecutingOpsName, operations);
        }

        internal void ResetPerformanceCounters()
        {
            totalOperations.RawValue = 0;
            totalOperationsSuccess.RawValue = 0;
            totalOperationsFault.RawValue = 0;
            //operationsPerSecond.RawValue = 0;
            //averageDuration.RawValue = 0;
            //averageDurationBase.RawValue = 0;
            totalOperationsExecuting.RawValue = 0;
        }


        [DllImport("Kernel32.dll")]
        public static extern void QueryPerformanceCounter(ref long ticks);

        private class TicksOperationCorrelationState
        {
            public long startTime;
            public string operationName;
        }

        public object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            long startTime = 0;
            QueryPerformanceCounter(ref startTime);
            var operationName = PerOperationCounter.OperationName(request);
            totalOperationsExecuting.Increment(operationName);
            operationsStartedPerSecond.Increment(operationName);
            return new TicksOperationCorrelationState()
                       {
                           startTime = startTime,
                           operationName = operationName
                       };
        }

        public void AfterReceiveReply(ref Message reply, object correlationState)
        {
            var ticksOperationCorrelationState = (TicksOperationCorrelationState)correlationState;
            var startTime = ticksOperationCorrelationState.startTime;
            long endTime = 0;
            QueryPerformanceCounter(ref endTime);
            var ticks = endTime - startTime;
            var operationName = ticksOperationCorrelationState.operationName;
            totalOperations.Increment(operationName);
            operationsPerSecond.Increment(operationName);
            averageDuration.IncrementBy(operationName, ticks);
            averageDurationBase.Increment(operationName);
            if (reply.IsFault)
                totalOperationsFault.Increment(operationName);
            else
                totalOperationsSuccess.Increment(operationName);

            totalOperationsExecuting.Decrement(operationName);
        }
    }
}