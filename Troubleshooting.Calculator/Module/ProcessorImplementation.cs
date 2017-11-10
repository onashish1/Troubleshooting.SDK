using System;
using System.Collections.Generic;
using System.Text;
using Troubleshooting.Common.Services;

namespace Troubleshooting.Calculator.Module
{
    public class ProcessorImplementation
    {
        private ICoreService _coreService;
        public ProcessorImplementation(ICoreService coreService)//:this()
        {
            _coreService = coreService;
        }
        private static Stack<CalcRequest> calcStack = new Stack<CalcRequest>();
        public ProcessorImplementation(CalcRequest calcReq)
        {
            calcStack.Push(calcReq);
        }

        public void PerformCalculation()
        {
            
           
            object result;
            foreach (CalcRequest calcItem in calcStack)
            {
                
                if ((calcItem.Operands.Length == 3) && (calcItem.Operation == Operation.SUM.ToString())) //Todo check for all operations
                {
                    dynamic Message = _coreService.CreateMessage("Calculation");
                    Message.Operator = Operation.SUM;
                    Message.Operand = calcItem.Operands;
                    result = (calcItem.Operation == Operation.SUM.ToString()) ? calcItem.Operands[0] + calcItem.Operands[1] : 0;
                    Message.Result = result;
                    _coreService.PostMessage(Message);
                }
                else if ((calcItem.Operands.Length == 3) && (calcItem.Operation == Operation.SUB.ToString())) //Todo check for all operations
                {
                    dynamic Message = _coreService.CreateMessage("Calculation");
                    Message.Operator = Operation.SUB;
                    Message.Operand = calcItem.Operands;
                    result = (calcItem.Operation == Operation.SUB.ToString()) ? calcItem.Operands[0] - calcItem.Operands[1] : 0;
                    Message.Result = result;
                    _coreService.PostMessage(Message);
                }
                else if ((calcItem.Operands.Length == 3) && (calcItem.Operation == Operation.MUL.ToString())) //Todo check for all operations
                {
                    dynamic Message = _coreService.CreateMessage("Calculation");
                    Message.Operator = Operation.MUL;
                    Message.Operand = calcItem.Operands;
                    result = (calcItem.Operation == Operation.MUL.ToString()) ? calcItem.Operands[0] * calcItem.Operands[1] : 0;
                    Message.Result = result;
                    _coreService.PostMessage(Message);
                }
                else if ((calcItem.Operands.Length == 3) && (calcItem.Operation == Operation.DIV.ToString())) //Todo check for all operations
                {
                    dynamic Message = _coreService.CreateMessage("Calculation");
                    Message.Operator = Operation.DIV;
                    Message.Operand = calcItem.Operands;
                    result = (calcItem.Operation == Operation.DIV.ToString()) ? calcItem.Operands[0] / calcItem.Operands[1] : 0;
                    Message.Result = result;
                    _coreService.PostMessage(Message);
                }

            }
            
         //   return result;
        }
    }
    public class CalcRequest
    {
        public string Operation { get; set; }
        public int[] Operands { get; set; }
    }

    public enum Operation
    {
        SUM,
        SUB,
        MUL,
        DIV

    }

}
