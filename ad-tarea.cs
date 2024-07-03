using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

/***
* LA app debe tener para ver la tareas ejecutandose, al precionar click debe ver toda la informacion, etc....
* Debe poder excluir directorios(Si la tarea esta en ese directorio no se muestra)
* Debe ver la cantidad de ram de esas tarea el total comparado con el total de ram que tiene la pc. debe tener la opcion de no ver la ram que consume las tareas que estan excluidas
* Puede tener un monitor que monitoree una tarea en especifico.
* Debe tener un visor de red que vea que app estan conectadas al internet y cuanto pide.
* Debe poder crear, y detener procesos.
* Debe pornerle un color al proceso usado por esta app de color azul, debe ponerle color a procesos que comparten un padre como azul, y rojo a procesos criticos(Que esten en system o system32)
* Debe tener un icono del proceso. Para los de system32 y system debe tener un icono de windows.
* Todo: Agregar un boton que desactive la actualizacion automatica y otro que sea para actualizar.
*/
namespace administrador_tarea;

public partial class ad_tarea: Form{
    private ListView prg_panel;
    private string[] results;
    private bool active_update=true;
    Button BUpdate;
    public ad_tarea(){
        InitializeComponent();
        CreateListPrograms();
        //Iniiamos lo primero que el usuario vera.
        Process[] process = Process.GetProcesses();
        update_list(process,0);
        process=null;
        //Para ejecuttar las actualizaciones en segundo plano.
        System.Timers.Timer timer = new System.Timers.Timer(2000);
        timer.Elapsed += async ( sender, e ) => await update_if();
        timer.Start();
        create_controlls();
        //Teclas
        //this.KeyPress+=ad_tarea_KeyPress;
        this.KeyUp+=ad_tarea_KeyUp;
    }
    private void create_controlls(){
        BUpdate=new Button();
        BUpdate.Text="Actualizar-Resultados";
        BUpdate.Location=new Point((int)((size_app.Width-BUpdate.Width)/2.1),2);
        BUpdate.AutoSize=true;
        BUpdate.Click+=delegate(object sender, EventArgs e) {
            Process[] process = Process.GetProcesses();
            update_list(process,0);
        };
        this.Controls.Add(BUpdate);
    }
    void ad_tarea_KeyUp(object sender, KeyEventArgs e){
        // Si se soltó la tecla F5
        if (e.KeyCode == Keys.F5){
            Process[] process = Process.GetProcesses();
            update_list(process,0);
        }
    }
    private void CreateListPrograms(){
        // Create a new ListView control.
        prg_panel = new ListView();
        prg_panel.Bounds = new Rectangle(new Point(10,30), new Size(size_app.Width-20,200));

        // Set the view to show details.
        prg_panel.View = View.Details;
        // Allow the user to rearrange columns.
        prg_panel.AllowColumnReorder = true;
        // Select the item and subitems when selection is made.
        prg_panel.FullRowSelect = true;
        // Display grid lines.
        prg_panel.GridLines = true;
        // Sort the items in the list in ascending order.
        prg_panel.Sorting = SortOrder.Ascending;
        //Tendra un scroll
        prg_panel.Scrollable = true;
        // Add the ListView to the control collection.
        // Create columns for the items and subitems.
        // Width of -2 indicates auto-size.
        prg_panel.Columns.Add("Programas", -2, HorizontalAlignment.Left);
        prg_panel.Columns.Add("Id", -2, HorizontalAlignment.Left);
        prg_panel.Columns.Add("Memoria", -2, HorizontalAlignment.Left);
        prg_panel.Columns.Add("Ubicación", -2, HorizontalAlignment.Left);
        this.Controls.Add(prg_panel);
    }
    int update_list(Process[] process,int scroll_v){
        ListViewItem[] names=new ListViewItem[process.Length];
        int i=0;
        results=new string[process.Length];
        foreach (Process p in process){
            ListViewItem i_name=new ListViewItem(p.ProcessName,i);
            i_name.SubItems.Add(p.Id.ToString());
            i_name.SubItems.Add(p.PrivateMemorySize64.ToString());
             try{
                i_name.SubItems.Add(p.MainModule.FileName);
            }catch (Exception ex){
                i_name.SubItems.Add(ex.Message);
            }
            names[i]=i_name;
            results[i]=p.ProcessName;
            i++;
        }
        //Limpiamos y despues actualizamos.
        prg_panel.Items.Clear();
        prg_panel.Items.AddRange(names);
        return 0;
    }
    public async Task<int> update_if(){
        bool is_update=false;
        Process[] process = Process.GetProcesses();
        string[] p_name=new string[process.Length];
        if (process.Length!=results.Length){//Se elimino o agrego un proceso.
            is_update=true;
        }else{//Parece que son iguales, verificamos que sea asi:
            for (int i=0;i<process.Length;i++)
                if (process[i].ProcessName!=results[i]){
                    is_update=true;
                    break;
                }
        }
        if (!active_update){
            if (is_update){
                BUpdate.Enabled=true;
            }else{
                BUpdate.Enabled=false;
            }
            return 0;
        }
        if (is_update){
            update_list(process,0);
        }
        return 0;
    }
}
//Para hacer un reemplazo global en vim se usa:
//:%s/texto_a_buscar/reemplazo/g


/*
// Create two ImageList objects.
ImageList imageListSmall = new ImageList();
ImageList imageListLarge = new ImageList();

// Initialize the ImageList objects with bitmaps.
imageListSmall.Images.Add(Bitmap.FromFile("C:/Users/RUBI/Pictures/banco_seguro.ico"));
imageListSmall.Images.Add(Bitmap.FromFile("C:/Users/RUBI/Pictures/montaña.bmp"));
imageListLarge.Images.Add(Bitmap.FromFile("C:/Users/RUBI/Pictures/banco_seguro.ico"));
imageListLarge.Images.Add(Bitmap.FromFile("C:/Users/RUBI/Pictures/montaña.bmp"));

//Assign the ImageList objects to the ListView.
prg_panel.LargeImageList = imageListLarge;
prg_panel.SmallImageList = imageListSmall;

// Allow the user to edit item text.
//prg_panel.LabelEdit = true;

// Display check boxes.
//prg_panel.CheckBoxes = true;
*/