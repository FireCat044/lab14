using OpenTelemetry;
using OpenTelemetry.Exporter;
using OpenTelemetry.Trace;
using System.Diagnostics;

public class CustomExporter : BaseExporter<Activity>
{
    public override ExportResult Export(in Batch<Activity> batch)
    {
        foreach (var activity in batch)
        {
            Console.WriteLine($"Exporting activity: {activity.DisplayName}");
        }
        return ExportResult.Success;
    }
}
