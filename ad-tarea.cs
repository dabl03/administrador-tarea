using System;
using System.Drawing;
using System.Windows.Forms;
using System.ComponentModel;
/***
* LA app debe tener para ver la tareas ejecutandose, al precionar click debe ver toda la informacion, etc....
* Debe poder excluir directorios(Si la tarea esta en ese directorio no se muestra)
* Debe ver la cantidad de ram de esas tarea el total comparado con el total de ram que tiene la pc. debe tener la opcion de no ver la ram que consume las tareas que estan excluidas
* Puede tener un monitor que monitoree una tarea en especifico.
* Debe tener un visor de red que vea que app estan conectadas al internet y cuanto pide.
* Debe poder crear, y detener procesos.
* Debe pornerle un color al proceso usado por esta app de color azul, debe ponerle color a procesos que comparten un padre como azul, y rojo a procesos criticos(Que esten en system o system32)
* Debe tener un icono del proceso. Para los de system32 y system debe tener un icono de windows.
*/
namespace administradorTarea{
    public class ad_tarea: Form{
        public Button button1;
        [STAThread]
        public static void Main()
        {
          Application.EnableVisualStyles();
          Application.Run(new ad_tarea());
        }
        public ad_tarea(){
            InitializeComponent();
        }
        private void InitializeComponent(){ 
            // Aquí va el código para crear los componentes de la ventana
            button1 = new Button();
            button1.Size = new Size(40, 40);
            button1.Location = new Point(30, 30);
            button1.Text = "Click me";
            this.Controls.Add(button1);
            button1.Click += new EventHandler(button1_Click);
            // Changes the border to Fixed3D.
            FormBorderStyle = FormBorderStyle.Fixed3D;
            //FormBorderStyle = FormBorderStyle.Sizable;//Hace que la ventana se pueda cambiar de tamaño.
        }
        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hello World");
        }
    }
}
//Para hacer un reemplazo global en vim se usa:
//:%s/texto_a_buscar/reemplazo/g
