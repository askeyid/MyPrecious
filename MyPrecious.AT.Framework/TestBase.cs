using MyPrecious.AT.Framework;
using MyPrecious.AT.Framework.CustomExceptions;
using MyPrecious.AT.Framework.Logger;
using System.Diagnostics;

namespace MyPrecious.AT.Framework
{
    public abstract class TestBase
    {
        [ThreadStatic]
        protected static List<string> TestAttachedFilePaths;

        public virtual void TestStep(string stepName, Action action)
        {
            var watch = new Stopwatch();

            try
            {
                watch.Start();
                WriteLog.TestStepLog($"STARTED [{stepName}]", emptyLineCount: 0);
                action.Invoke();

                watch.Stop();
                WriteLog.TestStepLog(
                    $"ENDED SUCCESSFULLY [{stepName}], [EXECUTION_TIME: {watch.Elapsed.Seconds}s]");
            }
            catch (FatalTestingException ex)
            {
                watch.Stop();

                HandleException();
                WriteLog.Error($"FAILED [{stepName}], [EXECUTION_TIME: {watch.Elapsed.Seconds}s], {WriteLog.NewLine()} ERROR: {ex.Message}{WriteLog.NewLine()}");

                throw;
            }
            catch (Exception ex)
            {
                watch.Stop();
                WriteLog.Error($"FAILED [{stepName}], [EXECUTION_TIME: {watch.Elapsed.Seconds}s], {WriteLog.NewLine()} ERROR: {ex.Message}{WriteLog.NewLine()}");

                throw;
            }
        }

        protected virtual void HandleException()
        {
        }
    }
}