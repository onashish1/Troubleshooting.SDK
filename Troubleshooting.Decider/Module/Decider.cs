using System;
using System.Threading.Tasks;
using Troubleshooting.Common.Services;

namespace Troubleshooting.Decider.Module
{
    /// <summary>
    ///     This class needs to generate random operations of the types:
    ///     ADD, SUB, MUL, DIV.
    ///     The operations must be posted as a message to the rest of the actors.
    ///     A new operation should be generated and posted every 700 milliseconds.
    ///     This class should be initialized by the DecisionsService.
    /// </summary>
    internal class Decider
    {
        private int _operatorsRnd;
        public string Operator { get; set; }
        private ICoreService _coreService { get; set; }
       
        
        public Decider(ICoreService coreService):this()
        {
            _coreService = coreService;
           
        }
     
        
        public Decider()
        {
            SetDecider();
        }
        private async void SetDecider()
        {
            Random rnd = new Random();
            while (true)
            {
                await Task.Delay(700);
                dynamic Message = _coreService.CreateMessage("Operator");

                switch (rnd.Next(1, 4))
                {
                    case 1:
                        Operator = Operation.SUM.ToString();

                        break;
                    case 2:
                        Operator = Operation.SUB.ToString();
                        break;
                    case 3:
                        Operator = Operation.MUL.ToString();
                        break;
                    case 4:
                        Operator = Operation.DIV.ToString();
                        break;
                }
                Message.Operand = Operator;
                _coreService.PostMessage(Message);
            }

        }
    }

    public enum Operation
    {
        SUM=1,
        SUB=2,
        MUL=3,
        DIV=4

    }

}