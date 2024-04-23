using Gameplay.Towers;
using Gameplay.Units;

public class GameRegistry
{
    private readonly UnitRegistry _playerUnits;
    private readonly UnitRegistry _enemyUnits;
    private readonly TowerRegistry _playerTowers;
    private readonly TowerRegistry _enemyTowers;

    public GameRegistry(UnitRegistry playerUnits, UnitRegistry enemyUnits, TowerRegistry playerTowers, TowerRegistry enemyTowers)
    {
        _playerUnits = playerUnits;
        _enemyUnits = enemyUnits;
        _playerTowers = playerTowers;
        _enemyTowers = enemyTowers;
    }

    public (UnitRegistry units, TowerRegistry towers) ForEnemy(TeamId id) =>
        id == TeamId.Enemy
            ? (_playerUnits, _playerTowers)
            : (_enemyUnits, _enemyTowers);

    public (UnitRegistry units, TowerRegistry towers) For(TeamId id) =>
        id == TeamId.Player
            ? (_playerUnits, _playerTowers)
            : (_enemyUnits, _enemyTowers);
}