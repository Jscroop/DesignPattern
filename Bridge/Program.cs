using System;

namespace Bridge
{
    class Program
    {
        static void Main(string[] args)
        {
            var diffBrush = new DiffBrush();
            var brushType1 = "大号毛笔";
            var brushType2 = "小号毛笔";

            var brush = new Brush();
            var colorType1 = "红色";
            var colorType2 = "绿色";

            diffBrush.Draw(brushType1);
            brush.SetColor(colorType1);

            diffBrush.Draw(brushType1);
            brush.SetColor(colorType2);

            diffBrush.Draw(brushType2);
            brush.SetColor(colorType1);

            diffBrush.Draw(brushType2);
            brush.SetColor(colorType2);
        }
    }

    //实现类接口
    public interface IBrush
    {
        void SetColor(string colorType);
    }

    //实现类
    public class Brush : IBrush
    {
        public void SetColor(string colorType)
        {
            Console.WriteLine($"作图颜色为{colorType}");
        }
    }

    //抽象类
    public abstract class BrushDraw
    {
        //定义实现类接口对象
        protected IBrush Brush;

        //可包含业务方法
        public abstract void Draw(string brushType);
    }

    //扩充抽象类
    public class DiffBrush : BrushDraw
    {
        public override void Draw(string brushType)
        {
            Console.Write($"当前为{brushType}~");
        }
    }

}
