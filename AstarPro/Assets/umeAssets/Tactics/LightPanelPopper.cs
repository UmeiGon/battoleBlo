using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPanelPopper : SingleTon<LightPanelPopper>
{
    [SerializeField] GameObject LightPanelPre;
    Dictionary<Point2, GameObject> panelDic=new Dictionary<Point2, GameObject>();
    private void Awake()
    {
        CompornentUtility.FindCompornentOnScene<SetUpManager>().AddSetUpAction(CreatePanels);
    }
    void CreatePanels()
    {
        var bs = CompornentUtility.FindCompornentOnScene<BattleStage>();
        foreach (var b in bs.Blocks)
        {
            var bp = Instantiate(LightPanelPre);
            bp.transform.position = b.Value.transform.position;
            panelDic.Add(b.Key, bp);
            bp.SetActive(false);
        }
    }
    public void ActiveOn(Point2 _point, Color _color)
    {
        panelDic[_point].gameObject.SetActive(true);
        _color.a = 0.5f;
        panelDic[_point].GetComponentInChildren<Renderer>().material.color = _color;
    }
    public void ActiveOff(Point2 _point)
    {
        panelDic[_point].gameObject.SetActive(false);
    }
    public void AllActiveOff()
    {
        foreach (var p in panelDic)
        {
            ActiveOff(p.Key);
        }
    }
}
