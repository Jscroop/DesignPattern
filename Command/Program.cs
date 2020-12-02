using System;

namespace Command
{
    class Program
    {
        static void Main(string[] args)
        {
            var button = new FunctionButton("功能键xxx");
            var command = new MinimizeCommand();
            button.SetCommand(command);
            button.OnClick();

            Console.ReadKey();
        }
    }

    //抽象命令
    public abstract class Command
    {
        public abstract void Execute();
    }

    //调用者
    public class FunctionButton
    {
        public string Name { get; set; }

        private Command _command;

        public FunctionButton(string name)
        {
            Name = name;
        }

        public void SetCommand(Command command)
        {
            _command = command;
        }

        public void OnClick()
        {
            Console.WriteLine("点击功能键：");
            _command?.Execute();
        }
    }

    //接收者
    public class WindowHandler
    {
        public void Minimize()
        {
            Console.WriteLine("正在最小化窗口至托盘...");
        }
    }

    //具体命令
    public class MinimizeCommand : Command
    {
        private readonly WindowHandler _handler;

        public MinimizeCommand()
        {
            _handler = new WindowHandler();
        }

        public override void Execute()
        {
            _handler?.Minimize();
        }
    }





}
