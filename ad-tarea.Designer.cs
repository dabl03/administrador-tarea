namespace administrador_tarea;

partial class ad_tarea{
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;
    private Size size_app;
    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing)
    {
        if (disposing && (components != null))
        {
            components.Dispose();
        }
        base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
        size_app=new Size(800, 450);
        this.components = new System.ComponentModel.Container();
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.ClientSize = new System.Drawing.Size(size_app.Width, size_app.Height);
        this.Text = "Administrador de Tarea";
        //No queremos que se redimensione.
        this.FormBorderStyle = FormBorderStyle.FixedSingle;
        this.MaximizeBox=false;
        //Para detectar las teclas en la ventana.
        this.KeyPreview =true;
    }

    #endregion
}
