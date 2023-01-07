using UnityEngine;
using System.IO;

public class CSVManager 
{
    private static string reportDirectoryName = "Report";
    private static string reportFileName = "report.csv";
    private static string reportSeparator = ",";
    private static string[] reportHeaders = new string[7] {
        "GroupID",
        "SceneJump",
        //"BallHitPaddle_Left",
        //"BallHitPaddle_Right",
        "ContinueHit_Max",
        "ContinueHit_Total",

        "MissingBall_Total",
        //"MissingBall_Left",
        //"MissingBall_Right",

        "FrozenUsedTimes_Left",
        //"FireUsedTimes_Left",
        //"FrozenUsedTimes_Right",
        "FireUsedTimes_Right"
    };
    private static string timeStampHeader = "time stamp";

    //====Interactions=======
    public static void AppendToReport(string[] strings) {
        VerifyDirectory();
        VerifyFile();

        using (StreamWriter sw = File.AppendText(GetFilePath()))
        {
            string finalString = "";
            for (int i = 0; i < strings.Length; i++) {
                finalString += strings[i];
                finalString += reportSeparator;
            }
            finalString += GetTimeStamp();
            sw.WriteLine(finalString);
        }
    }

    public static void CreateReport() {
        VerifyDirectory();
        using (StreamWriter sw = File.CreateText(GetFilePath())){
            string finalString = "";
            for (int i = 0; i < reportHeaders.Length; i++) {
                finalString += reportHeaders[i];
                finalString += reportSeparator;
            }
            finalString += timeStampHeader;
            sw.WriteLine(finalString);
        }
    }

    //====Interactions=======


    //====Operations=======
    static void VerifyDirectory() {

        string dir = GetDirectoryPath();
        if (!Directory.Exists(dir))
        {
            Directory.CreateDirectory(dir);
        }

    }

    static void VerifyFile() {
        string file = GetFilePath();
        if (!File.Exists(file)) {
            CreateReport();
        }
    }
    //====Operations=======



    //====Queries=======

    static string GetDirectoryPath() {

        return Application.persistentDataPath + "/" + reportDirectoryName;
    }

    static string GetFilePath() {
        return GetDirectoryPath() + "/" + reportFileName;
    }

    static string GetTimeStamp() {

        return System.DateTime.UtcNow.ToString();
    }
    //====Queries=======
}
