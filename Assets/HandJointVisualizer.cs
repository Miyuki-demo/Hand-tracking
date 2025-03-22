using UnityEngine;
using Unity.XR.PXR;
public class HandJointVisualizer : MonoBehaviour
{
    [Header("Here perfeb")]
    public GameObject lhandjoint;
    public GameObject rhandjoint;
    private GameObject[] ljoint = new GameObject[26];
    private GameObject[] rjoint = new GameObject[26];

    void Start()
    {
        if (lhandjoint == null || rhandjoint == null)
        {
            Debug.LogError("Error");
            return;
        }
        for (int i = 0; i < 26; i++)
        {
            ljoint[i] = Instantiate(lhandjoint, transform);
            ljoint[i].name = "n_" + i;
            ljoint[i].SetActive(false);
        }
        for (int i = 0; i < 26; i++)
        {
            rjoint[i] = Instantiate(lhandjoint, transform);
            rjoint[i].name = "n_" + i;
            rjoint[i].SetActive(false);
        }
    }
    void Update()
    {
        HandJointLocations LjointData = new HandJointLocations();
        LjointData.jointLocations = new HandJointLocation[26];
        HandJointLocations RjointData = new HandJointLocations();
        RjointData.jointLocations = new HandJointLocation[26];
        bool success1 = PXR_HandTracking.GetJointLocations(HandType.HandRight, ref RjointData);
        bool success2 = PXR_HandTracking.GetJointLocations(HandType.HandLeft, ref LjointData);
        if (!success1 || RjointData.isActive != 1 && !success2 || LjointData.isActive != 1)
        {
            visible(false);
            return;
        }
        for (int i = 0; i < 26; i++)
        {
            Vector3 position = RjointData.jointLocations[i].pose.Position.ToVector3();
            rjoint[i].transform.position = position;
            rjoint[i].SetActive(true);
        }
        for (int i = 0; i < 26; i++)
        {
            Vector3 position = LjointData.jointLocations[i].pose.Position.ToVector3();
            ljoint[i].transform.position = position;
            ljoint[i].SetActive(true);
        }
    }
    void visible(bool visible)
    {
        foreach (GameObject joint in ljoint)
        {
            if (joint != null) joint.SetActive(visible);
        }
        foreach (GameObject joint in rjoint)
        {
            if (joint != null) joint.SetActive(visible);
        }
    }
}