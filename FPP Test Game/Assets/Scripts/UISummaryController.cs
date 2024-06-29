using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UISummaryController : MonoBehaviour
{
    [SerializeField] TMP_Text totalTimeText;
    [SerializeField] TMP_Text correctNeutralizedDoorsText;
    [SerializeField] TMP_Text correctNeutralizedRoomsText;
    [SerializeField] TMP_Text errorsText;
    [SerializeField] TMP_Text failureToTakeMeasurementText;
    [SerializeField] TMP_Text tooHighRingSettingText;
    [SerializeField] TMP_Text tooSmallRingSettingText;
    [SerializeField] TMP_Text wrongRingSettingInRoomText;
    [SerializeField] TMP_Text skippedWallsText;
    [SerializeField] TMP_Text moreThanOneWallHittedText;

    public void UpdateStatistics()
    {
        totalTimeText.text += Mathf.Ceil(Time.timeSinceLevelLoad - GameManager.Instance.GetSecondStageStartTime());
        correctNeutralizedDoorsText.text += GameStatistics.correctNeutralizedDoors.ToString();
        correctNeutralizedRoomsText.text += GameStatistics.correctNeutralizedRooms.ToString();

        failureToTakeMeasurementText.text += GameStatistics.noMeasurementError.ToString();

        tooHighRingSettingText.text += GameStatistics.tooHighRingValueDoorsError.ToString();
        tooSmallRingSettingText.text += GameStatistics.tooLowRingValueDoorsError.ToString();

        wrongRingSettingInRoomText.text += GameStatistics.wrongRingValueInRoomError.ToString();
        skippedWallsText.text += GameStatistics.missedWallsInRoomError.ToString();
        moreThanOneWallHittedText.text += GameStatistics.moreThanOneShootToWallError.ToString();
    }
}
