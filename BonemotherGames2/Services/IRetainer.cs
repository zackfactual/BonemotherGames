using BonemotherGames2.Entities;

namespace BonemotherGames.Services
{
    public interface IRetainer
    {
        public RetainerClass GetRandomRetainerClass();
        public Ancestry GetRandomAncestry();
        public Name GetRandomName();
    }
}
