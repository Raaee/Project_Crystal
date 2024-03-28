using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu]
public class TaggedRuleTile : RuleTile
{
    public string tag;

    public override bool RuleMatch(int neighbor, TileBase other)
    {
        if (other is RuleOverrideTile)
            other = (other as RuleOverrideTile).m_InstanceTile;

        switch (neighbor)
        {
            case TilingRule.Neighbor.This:
                return other is TaggedRuleTile
                && (other as TaggedRuleTile).tag == tag;
            case TilingRule.Neighbor.NotThis:
                return other is not TaggedRuleTile
                || (other as TaggedRuleTile).tag != tag;
        }

        return base.RuleMatch(neighbor, other);
    }
}