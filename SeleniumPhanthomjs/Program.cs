using SeleniumPhanthomjs;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeleniumPhanthomjs.Process;

namespace SeleniumPhanthomjs
{
    class Program
    {
        static int Main(string[] args)
        {

            int flag1, flag2, flag3;

            flag1 = flag2 = flag3 = 0;

            //PrincipalPage pp = new PrincipalPage();

            //flag1 = pp.main();

            //MiddlePage mp = new MiddlePage();

            //flag2 = mp.Main();

            //FinalPage fp = new FinalPage();

            //flag3 = fp.main();

            UnifyProcess uprocess = new UnifyProcess();

            flag3 = uprocess.Main();


            if (flag1 + flag2 + flag3 == 0)
            {
                return 0;
            }
            else
            {
                return 1;
            }

            
        }
    }
}
