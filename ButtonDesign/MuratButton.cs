using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace ButtonDesign
{
    public class MuratButton : Button
    {
        public int ButtonSize_x;
        public int ButtonSize_y;
        public int ButtonLocation_x;
        public int ButtonLocation_y;

        Timer timer = new Timer();
        public MuratButton()
        {

            //arka plan rengi başlangıçta dodgerblue;
            //isteğe göre değiştirilebilir.
            BackColor = Color.FromArgb(49, 49, 49);
            Size = new Size(100, 50);
            ForeColor = Color.WhiteSmoke;

        }

        //rectangle çiziyoruz ve arka plan rengini,texti belirliyoruz
        protected override void OnPaint(PaintEventArgs pevent)
        {
            pevent.Graphics.FillRectangle(new SolidBrush(this.BackColor), 0, 0, this.Width, this.Height);
            TextFormatFlags flags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter;
            TextRenderer.DrawText(pevent.Graphics, this.Text, this.Font, new Point(Width + 3, this.Height / 2), this.ForeColor, flags);
        }

        protected override void OnMouseEnter(EventArgs e)
        {

            base.OnMouseEnter(e);
            BackColor = Color.FromArgb(82, 82, 82);
            //İlk başta mouse ile butonun üzerine geldiğimizde butonun o anki genişlik ve yüksekliğini almamız gerek.
            //Çünkü kullanıcı o an buton boyutunu küçültmüş yada büyültmüş olabilir.
            //Biz Default olarak (100,50) verdik fakat kullanıcı boyutu değişirse ve biz bu değerleri mouse enter'da
            //almazsak tıkladığımızda boyutu küçülteceğiz fakat tıklamayı geri çektiğimizde(mouseUP) geriye
            //hangi boyuta döndereceğimizi bilmemiz lazım.
            ButtonSize_x = this.Size.Width;
            ButtonSize_y = this.Size.Height;

            //Aynı şekilde o anki butonun location değerini alıyoruz. Biz butonu küçülttüğümüzde küçülmenin center
            //bir şekilde olması için yani alt-üst-sağ-sol olarak eşit küçülmesini ve büyümesini istediğimiz için
            //location değerleriyle oynamamız gerek.
            ButtonLocation_x = this.Location.X;
            ButtonLocation_y = this.Location.Y;

            //Mouse ile butonun üzerine geldiğimizde bir timer başlatıyoruz.
            //BU timer butonun üzerine geldiğimizde text yazımızı yani ForeColor değiştirmemizi sağlayacak.
            //randomColorChange ise bizim buton text renk değişim hızımızı ayarlamamızı sağlayacak
            timer.Interval = randomColorChange;//Saniyenin 10'da biri hızında değişim 6 salise de bir
            timer.Tick += change;//change eventine git.
            timer.Enabled = true;
            if(randomChangeTextColor==true)
            {
                timer.Start();
            }
            else
            {
                timer.Stop();
            }

        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            BackColor = Color.FromArgb(49, 49, 49);
            ButtonSize_x = 0;
            ButtonSize_y = 0;
            timer.Stop();
            ForeColor = Color.WhiteSmoke;
        }
        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);
            //BackColor = Color.FromArgb(32,73,105);
            BackColor = MouseDownBackcolor;
            /*
             *Tıklandığında buton boyutu kullanıcının girdiği değer kadar azalacak 
             *fakat biz simetrik bir azalma istediğimiz için x,y-10 azalırsa
             *bizim azalttığımız değerin yarısı kadar bir location oynaması yapmamız lazım.
             * bu yüzden girilen değer/2 yapıyoruz.
             */          
            Size = new Size(ButtonSize_x - clickEventSize, ButtonSize_y - clickEventSize);
            Location = new Point(ButtonLocation_x + clickEventSize/2, ButtonLocation_y + clickEventSize/2);

        }
        void change(object sender, EventArgs e)
        {
            //0-255 arası randon sayı oluşturup forecoloru rgb olarak renklendiriyoruz.
            //Bu her tick 6 salise de bir renk değiştirecek.
            Random color = new Random();
            ForeColor = Color.FromArgb(color.Next(255), color.Next(255), color.Next(255));

        }
        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            //mouse(bas-çek) olarak adlandırırsak çek kısmında çalışacak olan kısımdır.
            base.OnMouseUp(mevent);
            //backcolor default tanımlanan değere dönüyor.
            BackColor = Color.FromArgb(49, 49, 49);
            //tıklamayı geri çektiğimizde eski değerlerine yani, MouseEnter ile aldığımız değerlere geri dönderiyoruz.
            Size = new Size(ButtonSize_x, ButtonSize_y);
            Location = new Point(ButtonLocation_x, ButtonLocation_y);


        }


        //BU ALAN BUTONUMUZUN PROPERTY PENCERESİNDE YÖNETECEK OLDUĞUMUZ ALANLARIN TASARIMI İÇİN.


        //Bu ayar tıkladığımızda renk değişimi için gerekli ayardır.
        //Default olarak (82,82,82) renk kodlarını veriyoruz.
        private Color mouseDownBackcolor = Color.FromArgb(82, 82, 82);
        public Color MouseDownBackcolor
        {
            //value değeri bizim için hazır olarak verilir. Bu değer kullanıcının seçtiği değerdir.
            //seçilen değer private mouseColor'a aktarılır ve bu değeri geri döndeririz.
            //Bunuda Yukarıdaki onMouseDown eventinde BackColor değişkenine arıyoruz.
            get { return mouseDownBackcolor; }
            set { mouseDownBackcolor = value; }
        }


        //Burada butonun basılınca ne kadar küçüleceğinizi belirtiyoruz.
        //Default olarak 10 verdim. Kullanıcı Properties penceresinden dilediği gibi değiştirebilir.
        private Int32 clickEventSize = 10;
        public Int32 ClickEventSize
        {
            get { return clickEventSize; }
            set { clickEventSize = value; }
        }


        //Biz bir timer oluşturmuştuk ve timer her 6 salisede bir renk değiştiriyordu.
        //Bu ben bu properties de değişme hızını kullanıcıya bıraktım.
        private Int32 randomColorChange = 100;
        public Int32 RandomColorChange
        {
            get { return randomColorChange; }
            set { randomColorChange = value; }
        }

        //Bu alanda ise rastgele renk değişimi için açma kapama özelliği ekledim.
        //Bu değeri MouseEnter eventinde kontrole tabi tutarak true ise timer'i başlat, false ise timer'i durdur.
        //Yani timer başlarsa renk değişimi meydana gelecek (change metodu dolayısıyla). timer başlamazsa renk değişimi olmayacaktır.
        private Boolean randomChangeTextColor = true;
        public Boolean RandomChangeTextColor
        {
            get { return randomChangeTextColor; }
            set { randomChangeTextColor = value; }
        }

    }
}
