namespace ArmyWebAppUI
{
    public interface IHomeRepository
    {
        Task<IEnumerable<Weapon>> GetWeapons(string sTerm = "", int armytypeId = 0);
        Task<IEnumerable<ArmyType>> ArmyTypes();
    }
}