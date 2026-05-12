namespace FruitNinjaWinFormsApp
{
    public class CutBall : FruitBall
    {
        public CutBall(Form form, int pointX, int pointY, int radius, Color color, int vx) : base(form)
        {
            centerY = pointY;
            centerX = pointX;
            this.radius = radius / 2;

            brush = new SolidBrush(color);

            this.vx = vx;
            vy = -5;
        }

        public override void Move()
        {
            vy += g;
            Go();
        }
    }
}
