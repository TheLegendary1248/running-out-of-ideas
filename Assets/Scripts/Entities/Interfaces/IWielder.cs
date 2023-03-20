using System.Collections.ObjectModel;
/// <summary>
/// Class for all entities that can wield a weapon. Unlikely I use this as intended, but who knows
/// </summary>
public interface IWielder
{
    public ObservableCollection<SO_Launcher> holding { get; set; }
    public int currentHeld { get; set; }
}
