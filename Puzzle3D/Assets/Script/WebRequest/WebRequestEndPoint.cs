using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WebRequestEndPoint
{
    public const string INTERNET_URL = "http://localhost/Puzzle/";
    public const string GET_RESULT = "getResult.php";
    public const string INSERT_RESULT = "insertResult.php";

    public static string getURL(string _url){
        return INTERNET_URL + _url;
    }
}
