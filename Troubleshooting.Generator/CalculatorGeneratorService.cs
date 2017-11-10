using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Troubleshooting.Common.Services;

namespace Troubleshooting.Generator
{

    //This class needs to generate random intengers from 1 to 100.
    ///     The integers must be posted as a message to the rest of the actors.
    ///     A new integer should be generated and posted every 300 milliseconds.
    ///     This class should be initialized by the GeneratorService.

   public class CalculatorGeneratorService
    {
        private ICoreService _coreService;
        public int Operand1 { get; set; }
        Random rnd = new Random();

        public CalculatorGeneratorService(ICoreService coreService) 
        {
            _coreService = coreService;
          
        }
        // public int Operand2 { get; set; }
        public void RunCalculatorGeneratorService()
        {

            while (true)
            {
                SetOperand();

            }

            
        }

        private async void SetOperand()
        {
            dynamic Message = _coreService.CreateMessage("Operand");
            await Task.Delay(300);
            Operand1 = rnd.Next(1, 100);
            Message.Operand = Operand1;
            _coreService.PostMessage(Message);
        }
    }
}
