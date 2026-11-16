namespace NEXUS.windowsforms;

using System.Diagnostics;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private async void StartSimulation(object? sender, EventArgs e)
    {
        var consoleApp = FindConsoleApp();
        if (consoleApp is null)
        {
            MessageBox.Show("No se encontró la versión de consola. Compila la solución completa en Visual Studio e inténtalo de nuevo.",
                "NEXUS | No se pudo iniciar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        Process game;
        try
        {
            game = Process.Start(new ProcessStartInfo
            {
                FileName = consoleApp,
                WorkingDirectory = Path.GetDirectoryName(consoleApp)!,
                UseShellExecute = true,
                WindowStyle = ProcessWindowStyle.Normal
            })!;
        }
        catch (Exception ex)
        {
            MessageBox.Show($"No se pudo iniciar el juego en consola.\n\n{ex.Message}",
                "NEXUS | Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }

        Hide();
        try
        {
            await game.WaitForExitAsync();
        }
        finally
        {
            game.Dispose();
            if (!IsDisposed && IsHandleCreated)
            {
                Show();
                WindowState = FormWindowState.Normal;
                Activate();
            }
        }
    }

    private static string? FindConsoleApp()
    {
        var directory = new DirectoryInfo(AppContext.BaseDirectory);
        while (directory is not null && !File.Exists(Path.Combine(directory.FullName, "nexus_v2.csproj")))
            directory = directory.Parent;

        if (directory is null) return null;

        var configuration = Directory.GetParent(AppContext.BaseDirectory.TrimEnd(Path.DirectorySeparatorChar))?.Name ?? "Debug";
        var executable = Path.Combine(directory.FullName, "bin", configuration, "net8.0", "nexus_v2.exe");
        return File.Exists(executable) ? executable : null;
    }

    private void ShowMaps(object? sender, EventArgs e) => ShowModule(
        "MAPAS DE REALIDADES",
        "Zonas disponibles para explorar:\n\n• Bosque de Cristal\n• Ruinas de IRIS\n• Zona de Anomalía\n• Punto de Extracción");

    private void ShowSystemInfo(object? sender, EventArgs e) => ShowModule(
        "INFORMACIÓN DEL SISTEMA",
        "NEXUS v1.0\nSistema de inmersión\nProtocolo activo: IRIS\nEstado: en línea");

    private void OpenSettings(object? sender, EventArgs e)
    {
        var result = MessageBox.Show("¿Quieres alternar entre pantalla completa y modo ventana?", "NEXUS | Configuración",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        if (result != DialogResult.Yes) return;

        if (FormBorderStyle == FormBorderStyle.None)
        {
            WindowState = FormWindowState.Normal;
            FormBorderStyle = FormBorderStyle.Sizable;
            Size = new Size(1280, 720);
            StartPosition = FormStartPosition.CenterScreen;
        }
        else
        {
            FormBorderStyle = FormBorderStyle.None;
            WindowState = FormWindowState.Maximized;
        }
    }

    private void Disconnect(object? sender, EventArgs e)
    {
        if (MessageBox.Show("¿Deseas salir del sistema NEXUS?", "NEXUS | Desconectar",
            MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            Close();
    }

    private void ShowModule(string title, string message) => MessageBox.Show(message, $"NEXUS | {title}",
        MessageBoxButtons.OK, MessageBoxIcon.Information);
}
