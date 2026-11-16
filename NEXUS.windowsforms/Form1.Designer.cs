#nullable enable

namespace NEXUS.windowsforms;

partial class Form1
{
    private System.ComponentModel.IContainer? components;

    protected override void Dispose(bool disposing)
    {
        if (disposing) components?.Dispose();
        base.Dispose(disposing);
    }

    private void InitializeComponent()
    {
        components = new System.ComponentModel.Container();
        SuspendLayout();

        var backgroundPath = Path.Combine(AppContext.BaseDirectory, "Assets", "nexus-main-menu.png");
        using (var source = Image.FromFile(backgroundPath))
            BackgroundImage = new Bitmap(source);
        BackgroundImageLayout = ImageLayout.Stretch;
        BackColor = Color.FromArgb(2, 13, 30);
        ClientSize = new Size(800, 450);
        MinimumSize = new Size(720, 430);
        FormBorderStyle = FormBorderStyle.Sizable;
        KeyPreview = true;
        Name = "NexusMainForm";
        StartPosition = FormStartPosition.CenterScreen;
        Text = "NEXUS | Sistema de inmersión";
        WindowState = FormWindowState.Normal;
        KeyDown += (_, e) => { if (e.KeyCode == Keys.Escape) Close(); };
        Resize += (_, _) => PositionHotspots();

        AddHotspot("Iniciar simulación", 0.602, 0.374, 0.344, 0.098, StartSimulation);
        AddHotspot("Mapas de realidades", 0.606, 0.484, 0.337, 0.084, ShowMaps);
        AddHotspot("Información del sistema", 0.606, 0.570, 0.337, 0.083, ShowSystemInfo);
        AddHotspot("Configuración", 0.606, 0.657, 0.337, 0.082, OpenSettings);
        AddHotspot("Desconectar", 0.606, 0.744, 0.337, 0.082, Disconnect);

        ResumeLayout(false);
    }

    private void AddHotspot(string label, double x, double y, double width, double height, EventHandler onClick)
    {
        var button = new Button
        {
            Name = $"hotspot{Controls.Count + 1}",
            AccessibleName = label,
            AccessibleDescription = $"Abrir {label.ToLowerInvariant()}",
            TabIndex = Controls.Count,
            Text = string.Empty,
            FlatStyle = FlatStyle.Flat,
            BackColor = Color.Transparent,
            Cursor = Cursors.Hand,
            UseVisualStyleBackColor = false
        };
        button.FlatAppearance.BorderSize = 0;
        button.FlatAppearance.MouseOverBackColor = Color.FromArgb(34, 0, 164, 255);
        button.FlatAppearance.MouseDownBackColor = Color.FromArgb(58, 0, 194, 255);
        button.Click += onClick;
        button.Tag = new RectangleF((float)x, (float)y, (float)width, (float)height);
        Controls.Add(button);
        button.BringToFront();
        PositionHotspots();
    }

    private void PositionHotspots()
    {
        foreach (var button in Controls.OfType<Button>())
        {
            var area = (RectangleF)button.Tag!;
            button.Bounds = new Rectangle(
                (int)(ClientSize.Width * area.X),
                (int)(ClientSize.Height * area.Y),
                (int)(ClientSize.Width * area.Width),
                (int)(ClientSize.Height * area.Height));
        }
    }
}
