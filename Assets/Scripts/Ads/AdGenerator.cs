using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdGenerator : MonoBehaviour
{
  public static string[] w1 = new string[]{
    "Free",
    "Unique",
    "Amazing",
    "Life changing",
    "Interesting",
    "Awesome",
    "Cheap",
    "Great",
    "Once in a life time chance to get",
    "Get",
    "Immediately download",
  };
  public static string[] w2 = new string[]{
    "Coupons",
    "Apple",
    "Gift",
    "Website",
    "Headphones",
    "Certificate",
    "Lootbox",
    "RAM",
    "Computer",
    "Vodka",
    "Bible",
    "Hot sauce",
    "Water supply",
    "5 Star food",
    "Fidget spinner",
    "Fidget cube",
    "Washing machine",
    "Dish washer",
    "Bathtub",
    "Virtual assistant",
    "VPN",
    "VPS",
    "Book",
    "Tablet",
    "Laptop",
    "Iphone",
    "Ads",
    "Pillow",
    "Poster",
    "Job",
    "Tesla",
    "Trip to mars",
    "Bitcoin",
    "Holiday trip",
  };
  public static string[] w3 = new string[]{
    "In",
    "For",
    "Within",
    "On",
    "Until",
    "Before",
    "After",
  };
  public static string[] w4 = new string[]{
    "This moment",
		"1 week",
		"Forever",
		"Lifetime",
		"3 days",
		"Black friday",
		"Cyber monday",
		"Christmas",
		"Boxing day",
		"Tommorow",
  };

	public static string generateAd(){
		string combinedSentence = w1[Random.Range(0, w1.Length)] + " " + w2[Random.Range(0, w2.Length)] + " " + w3[Random.Range(0, w3.Length)] + " " + w4[Random.Range(0, w4.Length)];
		return combinedSentence;
	}
}
