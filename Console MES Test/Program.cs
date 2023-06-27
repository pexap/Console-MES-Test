using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Camstar.WCF;
using Camstar.WCF.ObjectStack;
using Camstar.Util;
using Camstar.Exceptions;
using Camstar.WCF.Services;

namespace Console_MES_Test
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {

                MoveStdService oCDOService = new MoveStdService(new UserProfile("Administrator", "Ocg123!"));
                MoveStd oCDO = new MoveStd { Container = new ContainerRef("AAA") };
                ResultStatus oResultStatus = oCDOService.ExecuteTransaction(oCDO);

                if (oResultStatus.IsSuccess)
                {
                    Console.WriteLine(oResultStatus.Message);
                }
                else throw new Exception(oResultStatus.ExceptionData.Description);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadKey();
        }
    }
}