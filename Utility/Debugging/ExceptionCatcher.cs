using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utility.Debugging
{
    public static class ExceptionCatcher
    {
        public static Exception Excute(this Action action, Action finalAction = null)
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return ex;
            }
            finally
            {
                if (finalAction != null)
                    finalAction();
            }

            return null;
        }

        public static void example()
        {
            Action catcher = delegate
            {
                Console.WriteLine("forced exeption");
                List<int> ii = new List<int>();
                int i = ii[3];

                Console.WriteLine(i);
            };

            Exception ex = catcher.Excute();



            catcher = delegate
            {
                Console.WriteLine("normal");
            };

            ex = catcher.Excute();
        }
    }
}
