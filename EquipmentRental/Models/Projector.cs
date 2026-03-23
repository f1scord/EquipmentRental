namespace EquipmentRental.Models;

public class Projector : Equipment
{
    public int BrightnessLumens { get; set; }
    public bool HasHdmiInput { get; set; }

    public Projector(string name, int brightnessLumens, bool hasHdmiInput) : base(name)
    {
        BrightnessLumens = brightnessLumens;
        HasHdmiInput = hasHdmiInput;
    }

    public override string GetInfo()
    {
        return $"Projector brightness: {BrightnessLumens}, projector has HDMI port: {HasHdmiInput}";
    }
}