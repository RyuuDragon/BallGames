namespace FruitNinjaWinFormsApp
{
    public class BananBall : FruitBall
    {
        public BananBall(Form form) : base(form)
        {
            brush = new SolidBrush(Color.Yellow);
            radius = 30;
        }

        public override void Draw(Graphics graphics)
        {
            var rectangle = new RectangleF(centerX - radius, centerY - radius, radius * 2, radius * 2);
            graphics.FillEllipse(brush, rectangle);

            var text = "Банан";
            var font = new Font("Arial", 10, FontStyle.Bold);
            var textBrush = Brushes.Red;

            var textSize = graphics.MeasureString(text, font);

            var textX = centerX - (textSize.Width / 2);
            var textY = centerY - (textSize.Height / 2);

            graphics.DrawString(text, font, textBrush, textX, textY);
        }
    }
}
