using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoccerTeamSelector : ButtonBase
{
    [SerializeField] private int _teamIndex;
    [SerializeField] private TeamOrigin _teamOrigin;
    [SerializeField] private SoccerTeamName _teamName;
    private Contest _contest;

    private void Awake()
    {
        base.Awake();
        _contest = ContestManager.Instance.Contests[0];
        Team team = _contest.GetAllTeams()[0];
        _menuController.OnTeamSelect(team, TeamOrigin.Home);
        team = _contest.GetAllTeams()[1];
        _menuController.OnTeamSelect(team, TeamOrigin.Away);
    }

    public override void OnClick()
    {
        Team team = _contest.GetAllTeams()[_teamIndex];
        _menuController.OnTeamSelect(team, _teamOrigin);
        _teamName.UpdateText(team.Name);
    }
}
