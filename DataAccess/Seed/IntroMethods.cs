﻿using WRMC.Infrastructure.Domain.Entities;
using WRMC.Infrastructure.Domain.Enums;

namespace WRMC.Infrastructure.DataAccess.Context
{
    static partial class Seed
    {

        public static List<IntroMethod> IntroMethods = new List<IntroMethod> {
            new IntroMethod {Id=1,ParentId = null,Type = TreeTypeEnum.Root,Name = "Advertisement",DisplayTitle = "Advertisement",Description = "Advertisement",Order = 1,AdditionalInfoRequired=false,},
            new IntroMethod {Id=10,ParentId = null,Type = TreeTypeEnum.Root,Name = "MedicalReferrals",DisplayTitle = "Medical Referrals",Description = "Medical Referrals",Order = 2,AdditionalInfoRequired=false,},
            new IntroMethod {Id=11,ParentId = null,Type = TreeTypeEnum.Root,Name = "GovernmentAgencies",DisplayTitle = "Government Agencies",Description = "Government Agencies",Order = 3,AdditionalInfoRequired=false,},
            new IntroMethod {Id=12,ParentId = null,Type = TreeTypeEnum.Root,Name = "AlcoholDrugRehabs",DisplayTitle = "Alcohol/Drug Rehabs",Description = "Alcohol/Drug Rehabs",Order = 4,AdditionalInfoRequired=false,},
            new IntroMethod {Id=13,ParentId = null,Type = TreeTypeEnum.Root,Name = "Shelters",DisplayTitle = "Shelters",Description = "Shelters",Order = 5,AdditionalInfoRequired=false,},
            new IntroMethod {Id=14,ParentId = null,Type = TreeTypeEnum.Root,Name = "ChurchReferral",DisplayTitle = "Church Referral",Description = "Church Referral",Order = 6,AdditionalInfoRequired=false,},
            new IntroMethod {Id=15,ParentId = null,Type = TreeTypeEnum.Root,Name = "AbortionClinic",DisplayTitle = "Abortion Clinic",Description = "Abortion Clinic",Order = 7,AdditionalInfoRequired=false,},
            new IntroMethod {Id=2,ParentId = null,Type = TreeTypeEnum.Leaf,Name = "FriendsRelativesPartner",DisplayTitle = "Friends/Relatives/Partner",Description = "Friends/Relatives/Partner",Order = 8,AdditionalInfoRequired=false,},
            new IntroMethod {Id=3,ParentId = null,Type = TreeTypeEnum.Leaf,Name = "RepeatClient",DisplayTitle = "Repeat Client",Description = "Repeat Client",Order = 9,AdditionalInfoRequired=false,},
            new IntroMethod {Id=4,ParentId = null,Type = TreeTypeEnum.Leaf,Name = "WalkInPasserBy",DisplayTitle = "Walk-in/Passer By",Description = "Walk-in/Passer By",Order = 10,AdditionalInfoRequired=false,},
            new IntroMethod {Id=5,ParentId = null,Type = TreeTypeEnum.Leaf,Name = "CrisisPregnancyCenters",DisplayTitle = "Crisis Pregnancy Centers",Description = "Crisis Pregnancy Centers",Order = 11,AdditionalInfoRequired=false,},
            new IntroMethod {Id=6,ParentId = null,Type = TreeTypeEnum.Leaf,Name = "OptionUnited",DisplayTitle = "Option United",Description = "Option United",Order = 12,AdditionalInfoRequired=false,},
            new IntroMethod {Id=7,ParentId = null,Type = TreeTypeEnum.Leaf,Name = "CommunityEvent",DisplayTitle = "Community Event",Description = "Community Event",Order = 13,AdditionalInfoRequired=false,},
            new IntroMethod {Id=8,ParentId = null,Type = TreeTypeEnum.Leaf,Name = "ChurchEvent",DisplayTitle = "Church Event",Description = "Church Event",Order = 14,AdditionalInfoRequired=false,},
            new IntroMethod {Id=9,ParentId = null,Type = TreeTypeEnum.Leaf,Name = "BabyFirstServices",DisplayTitle = "Baby First Services",Description = "Baby First Services",Order = 15,AdditionalInfoRequired=false,},
            new IntroMethod {Id=16,ParentId = null,Type = TreeTypeEnum.Leaf,Name = "HelpOfSouthernNevada",DisplayTitle = "Help of Southern Nevada",Description = "Help of Southern Nevada",Order = 16,AdditionalInfoRequired=false,},
            //Parent : Advertisement
            new IntroMethod {Id=20,ParentId = 1,Type = TreeTypeEnum.Leaf,Name = "TVCommercial",DisplayTitle = "TV Commercial",Description = "TV Commercial",Order = 1,AdditionalInfoLabel="TV Station",AdditionalInfoRequired=true,},
            new IntroMethod {Id=21,ParentId = 1,Type = TreeTypeEnum.Node,Name = "RadioAdvertisement",DisplayTitle = "Radio Advertisement",Description = "Radio Advertisement",Order = 2,AdditionalInfoRequired=false,},
            new IntroMethod {Id=24,ParentId = 1,Type = TreeTypeEnum.Node,Name = "SocialMedia",DisplayTitle = "Social Media",Description = "Social Media",Order = 3,AdditionalInfoRequired=false,},
            new IntroMethod {Id=17,ParentId = 1,Type = TreeTypeEnum.Leaf,Name = "Billboards",DisplayTitle = "Billboards",Description = "Billboards",Order = 4,AdditionalInfoRequired=false,},
            new IntroMethod {Id=18,ParentId = 1,Type = TreeTypeEnum.Leaf,Name = "BusStopFillers",DisplayTitle = "Bus Stop Fillers",Description = "Bus Stop Fillers",Order = 5,AdditionalInfoRequired=false,},
            new IntroMethod {Id=19,ParentId = 1,Type = TreeTypeEnum.Leaf,Name = "PhoneBookDirectories",DisplayTitle = "Phone book/Directories",Description = "Phone book/Directories",Order = 6,AdditionalInfoRequired=false,},
            new IntroMethod {Id=22,ParentId = 1,Type = TreeTypeEnum.Leaf,Name = "Flyers",DisplayTitle = "Flyers",Description = "Flyers",Order = 7,AdditionalInfoRequired=false,},
            new IntroMethod {Id=23,ParentId = 1,Type = TreeTypeEnum.Leaf,Name = "Newspaper",DisplayTitle = "Newspaper",Description = "Newspaper",Order = 8,AdditionalInfoRequired=false,},
            //Parent : RadioAdvertisement
            new IntroMethod {Id=25,ParentId = 21,Type = TreeTypeEnum.Leaf,Name = "SecularRadio",DisplayTitle = "Secular Radio",Description = "Secular",Order = 1,AdditionalInfoLabel="Radio Station",AdditionalInfoRequired=true,},
            new IntroMethod {Id=26,ParentId = 21,Type = TreeTypeEnum.Leaf,Name = "ChristianRadio",DisplayTitle = "Christian Radio",Description = "Christian",Order = 2,AdditionalInfoLabel="Radio Station",AdditionalInfoRequired=true,},
            new IntroMethod {Id=27,ParentId = 24,Type = TreeTypeEnum.Leaf,Name = "GoogleAds",DisplayTitle = "Google Ads",Description = "Google Ads",Order = 1,AdditionalInfoRequired=false,},
            new IntroMethod {Id=28,ParentId = 24,Type = TreeTypeEnum.Leaf,Name = "Facebook",DisplayTitle = "Facebook",Description = "Facebook",Order = 2,AdditionalInfoRequired=false,},
            new IntroMethod {Id=29,ParentId = 24,Type = TreeTypeEnum.Leaf,Name = "Yelp",DisplayTitle = "Yelp",Description = "Yelp",Order = 3,AdditionalInfoRequired=false,},
            new IntroMethod {Id=30,ParentId = 24,Type = TreeTypeEnum.Leaf,Name = "Instagram",DisplayTitle = "Instagram",Description = "Instagram",Order = 4,AdditionalInfoRequired=false,},
            new IntroMethod {Id=31,ParentId = 24,Type = TreeTypeEnum.Leaf,Name = "Twitter",DisplayTitle = "Twitter",Description = "Twitter",Order = 5,AdditionalInfoRequired=false,},
            new IntroMethod {Id=32,ParentId = 24,Type = TreeTypeEnum.Leaf,Name = "GameApps",DisplayTitle = "Game Apps",Description = "Game Apps",Order = 6,AdditionalInfoRequired=false,},
            new IntroMethod {Id=33,ParentId = 24,Type = TreeTypeEnum.Leaf,Name = "Tinder",DisplayTitle = "Tinder",Description = "Tinder",Order = 7,AdditionalInfoRequired=false,},
            new IntroMethod {Id=34,ParentId = 24,Type = TreeTypeEnum.Leaf,Name = "Signage",DisplayTitle = "Signage",Description = "Signage",Order = 8,AdditionalInfoRequired=false,},
            new IntroMethod {Id=35,ParentId = 24,Type = TreeTypeEnum.Leaf,Name = "MedicalMobileUnitSign",DisplayTitle = "Medical Mobile Unit Sign",Description = "Medical Mobile Unit Sign",Order = 9,AdditionalInfoRequired=false,},
            //Parent : MedicalReferrals
            new IntroMethod {Id=36,ParentId = 10,Type = TreeTypeEnum.Leaf,Name = "DrSauter",DisplayTitle = "Dr. Sauter",Description = "Dr. Sauter",Order = 1,AdditionalInfoRequired=false,},
            new IntroMethod {Id=37,ParentId = 10,Type = TreeTypeEnum.Leaf,Name = "DrHerrero",DisplayTitle = "Dr. Herrero",Description = "Dr. Herrero",Order = 2,AdditionalInfoRequired=false,},
            new IntroMethod {Id=38,ParentId = 10,Type = TreeTypeEnum.Leaf,Name = "DrStrebel",DisplayTitle = "Dr. Strebel",Description = "Dr. Strebel",Order = 3,AdditionalInfoRequired=false,},
            new IntroMethod {Id=39,ParentId = 10,Type = TreeTypeEnum.Leaf,Name = "UNLVMedicine",DisplayTitle = "UNLV Medicine",Description = "UNLV Medicine",Order = 4,AdditionalInfoRequired=false,},
            new IntroMethod {Id=40,ParentId = 10,Type = TreeTypeEnum.Leaf,Name = "BabyStepsUMC",DisplayTitle = "Baby Steps UMC",Description = "Baby Steps UMC",Order = 5,AdditionalInfoRequired=false,},
            new IntroMethod {Id=41,ParentId = 10,Type = TreeTypeEnum.Leaf,Name = "SunnyBabies",DisplayTitle = "Sunny Babies",Description = "Sunny Babies",Order = 6,AdditionalInfoRequired=false,},
            new IntroMethod {Id=42,ParentId = 10,Type = TreeTypeEnum.Leaf,Name = "MountainViewHospital",DisplayTitle = "Mountain View Hospital",Description = "Mountain View Hospital",Order = 7,AdditionalInfoRequired=false,},
            new IntroMethod {Id=43,ParentId = 10,Type = TreeTypeEnum.Leaf,Name = "HealthDepartment",DisplayTitle = "Health Department",Description = "Health Department",Order = 8,AdditionalInfoRequired=false,},
            //Parent : GovernmentAgencies
            new IntroMethod {Id=44,ParentId = 11,Type = TreeTypeEnum.Leaf,Name = "Welfare",DisplayTitle = "Welfare",Description = "Welfare",Order = 1,AdditionalInfoRequired=false,},
            new IntroMethod {Id=45,ParentId = 11,Type = TreeTypeEnum.Leaf,Name = "Medicaid",DisplayTitle = "Medicaid",Description = "Medicaid",Order = 2,AdditionalInfoRequired=false,},
            new IntroMethod {Id=46,ParentId = 11,Type = TreeTypeEnum.Leaf,Name = "WIC",DisplayTitle = "WIC",Description = "WIC",Order = 3,AdditionalInfoRequired=false,},
            new IntroMethod {Id=47,ParentId = 11,Type = TreeTypeEnum.Leaf,Name = "ChildFamilyServices",DisplayTitle = "Department of Child and Family Services",Description = "Department of Child and Family Services",Order = 4,AdditionalInfoRequired=false,},
            new IntroMethod {Id=48,ParentId = 11,Type = TreeTypeEnum.Leaf,Name = "Nevada211",DisplayTitle = "Nevada 211",Description = "Nevada 211",Order = 5,AdditionalInfoRequired=false,},
            //Parent : AlcoholDrugRehabs
            new IntroMethod {Id=49,ParentId = 12,Type = TreeTypeEnum.Leaf,Name = "WestCareRehab",DisplayTitle = "West Care Rehab",Description = "West Care Rehab",Order = 1,AdditionalInfoRequired=false,},
            new IntroMethod {Id=50,ParentId = 12,Type = TreeTypeEnum.Leaf,Name = "CenterForBehavioralHealth",DisplayTitle = "Center for Behavioral Health",Description = "Center for Behavioral Health",Order = 2,AdditionalInfoRequired=false,},
            new IntroMethod {Id=51,ParentId = 12,Type = TreeTypeEnum.Leaf,Name = "OtherAlcoholDrugRehabs",DisplayTitle = "Other",Description = "Other",Order = 3,AdditionalInfoRequired=false,},
            //Parent : Shelters
            new IntroMethod {Id=52,ParentId = 13,Type = TreeTypeEnum.Leaf,Name = "LasVegasRescueMission",DisplayTitle = "Las Vegas Rescue Mission",Description = "Las Vegas Rescue Mission",Order = 1,AdditionalInfoRequired=false,},
            new IntroMethod {Id=53,ParentId = 13,Type = TreeTypeEnum.Leaf,Name = "ShadeTree",DisplayTitle = "Shade Tree",Description = "Shade Tree",Order = 2,AdditionalInfoRequired=false,},
            new IntroMethod {Id=54,ParentId = 13,Type = TreeTypeEnum.Leaf,Name = "SafeNest",DisplayTitle = "SafeNest",Description = "SafeNest",Order = 3,AdditionalInfoRequired=false,},
            new IntroMethod {Id=55,ParentId = 13,Type = TreeTypeEnum.Leaf,Name = "NevadaYouthPartnership",DisplayTitle = "Nevada Youth Partnership",Description = "Nevada Youth Partnership",Order = 4,AdditionalInfoRequired=false,},
            new IntroMethod {Id=56,ParentId = 13,Type = TreeTypeEnum.Leaf,Name = "Other",DisplayTitle = "Other",Description = "Other",Order = 5,AdditionalInfoRequired=false,},
            //Parent : ChurchReferral
            new IntroMethod {Id=57,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "Grace Point Church",DisplayTitle = "Grace Point Church",Description = "Grace Point Church",Order = 1,AdditionalInfoRequired=false,},
            new IntroMethod {Id=58,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "Green Valley Baptist",DisplayTitle = "Green Valley Baptist",Description = "Green Valley Baptist",Order = 2,AdditionalInfoRequired=false,},
            new IntroMethod {Id=59,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "Green Valley Christian Center",DisplayTitle = "Green Valley Christian Center",Description = "Green Valley Christian Center",Order = 3,AdditionalInfoRequired=false,},
            new IntroMethod {Id=60,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "Harvest Life Christian Fellowship",DisplayTitle = "Harvest Life Christian Fellowship",Description = "Harvest Life Christian Fellowship",Order = 4,AdditionalInfoRequired=false,},
            new IntroMethod {Id=61,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "Highland Hills Baptist",DisplayTitle = "Highland Hills Baptist",Description = "Highland Hills Baptist",Order = 5,AdditionalInfoRequired=false,},
            new IntroMethod {Id=62,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "Hope Church",DisplayTitle = "Hope Church",Description = "Hope Church",Order = 6,AdditionalInfoRequired=false,},
            new IntroMethod {Id=63,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "Iglesia Agua Viva",DisplayTitle = "Iglesia Agua Viva",Description = "Iglesia Agua Viva",Order = 7,AdditionalInfoRequired=false,},
            new IntroMethod {Id=64,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "Iglesia Bautista Pan De Vida",DisplayTitle = "Iglesia Bautista Pan De Vida",Description = "Iglesia Bautista Pan De Vida",Order = 8,AdditionalInfoRequired=false,},
            new IntroMethod {Id=65,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "International Church of Las Vegas",DisplayTitle = "International Church of Las Vegas",Description = "International Church of Las Vegas",Order = 9,AdditionalInfoRequired=false,},
            new IntroMethod {Id=66,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "Jesus the Good Shepard Church",DisplayTitle = "Jesus the Good Shepard Church",Description = "Jesus the Good Shepard Church",Order = 10,AdditionalInfoRequired=false,},
            new IntroMethod {Id=67,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "Lake Mead Church",DisplayTitle = "Lake Mead Church",Description = "Lake Mead Church",Order = 11,AdditionalInfoRequired=false,},
            new IntroMethod {Id=68,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "Las Vegas Bible Church",DisplayTitle = "Las Vegas Bible Church",Description = "Las Vegas Bible Church",Order = 12,AdditionalInfoRequired=false,},
            new IntroMethod {Id=69,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "Las Vegas Church of the Nazarene",DisplayTitle = "Las Vegas Church of the Nazarene",Description = "Las Vegas Church of the Nazarene",Order = 13,AdditionalInfoRequired=false,},
            new IntroMethod {Id=70,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "Life Baptist Church",DisplayTitle = "Life Baptist Church",Description = "Life Baptist Church",Order = 14,AdditionalInfoRequired=false,},
            new IntroMethod {Id=71,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "Life Springs Christian Church",DisplayTitle = "Life Springs Christian Church",Description = "Life Springs Christian Church",Order = 15,AdditionalInfoRequired=false,},
            new IntroMethod {Id=72,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "Living Grace Foursquare Church",DisplayTitle = "Living Grace Foursquare Church",Description = "Living Grace Foursquare Church",Order = 16,AdditionalInfoRequired=false,},
            new IntroMethod {Id=73,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "Meadows Fellowship Christian Church",DisplayTitle = "Meadows Fellowship Christian Church",Description = "Meadows Fellowship Christian Church",Order = 17,AdditionalInfoRequired=false,},
            new IntroMethod {Id=74,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "Messiah's Christian Fellowship",DisplayTitle = "Messiah's Christian Fellowship",Description = "Messiah's Christian Fellowship",Order = 18,AdditionalInfoRequired=false,},
            new IntroMethod {Id=75,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "Moapa Christian Church",DisplayTitle = "Moapa Christian Church",Description = "Moapa Christian Church",Order = 19,AdditionalInfoRequired=false,},
            new IntroMethod {Id=76,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "Mountain View Lutheran Church",DisplayTitle = "Mountain View Lutheran Church",Description = "Mountain View Lutheran Church",Order = 20,AdditionalInfoRequired=false,},
            new IntroMethod {Id=77,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "Mountaintop Faith Ministries",DisplayTitle = "Mountaintop Faith Ministries",Description = "Mountaintop Faith Ministries",Order = 21,AdditionalInfoRequired=false,},
            new IntroMethod {Id=78,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "Mt. Charleston Baptist Church",DisplayTitle = "Mt. Charleston Baptist Church",Description = "Mt. Charleston Baptist Church",Order = 22,AdditionalInfoRequired=false,},
            new IntroMethod {Id=79,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "Neighborhood Church",DisplayTitle = "Neighborhood Church",Description = "Neighborhood Church",Order = 23,AdditionalInfoRequired=false,},
            new IntroMethod {Id=80,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "Nellis Baptist Church",DisplayTitle = "Nellis Baptist Church",Description = "Nellis Baptist Church",Order = 24,AdditionalInfoRequired=false,},
            new IntroMethod {Id=81,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "New Day Christian Church",DisplayTitle = "New Day Christian Church",Description = "New Day Christian Church",Order = 25,AdditionalInfoRequired=false,},
            new IntroMethod {Id=82,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "No church stated",DisplayTitle = "No church stated",Description = "No church stated",Order = 26,AdditionalInfoRequired=false,},
            new IntroMethod {Id=83,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "North Las Vegas Baptist Church",DisplayTitle = "North Las Vegas Baptist Church",Description = "North Las Vegas Baptist Church",Order = 27,AdditionalInfoRequired=false,},
            new IntroMethod {Id=84,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "Northstar Baptist Church",DisplayTitle = "Northstar Baptist Church",Description = "Northstar Baptist Church",Order = 28,AdditionalInfoRequired=false,},
            new IntroMethod {Id=85,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "Oasis Baptist Church",DisplayTitle = "Oasis Baptist Church",Description = "Oasis Baptist Church",Order = 29,AdditionalInfoRequired=false,},
            new IntroMethod {Id=86,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "Oasis Christian Church",DisplayTitle = "Oasis Christian Church",Description = "Oasis Christian Church",Order = 30,AdditionalInfoRequired=false,},
            new IntroMethod {Id=87,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "Our Lady of Las Vegas Catholic Church",DisplayTitle = "Our Lady of Las Vegas Catholic Church",Description = "Our Lady of Las Vegas Catholic Church",Order = 31,AdditionalInfoRequired=false,},
            new IntroMethod {Id=88,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "Our Savior's Lutheran Church",DisplayTitle = "Our Savior's Lutheran Church",Description = "Our Savior's Lutheran Church",Order = 32,AdditionalInfoRequired=false,},
            new IntroMethod {Id=89,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "Paradise Church",DisplayTitle = "Paradise Church",Description = "Paradise Church",Order = 33,AdditionalInfoRequired=false,},
            new IntroMethod {Id=90,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "Prince of Peace",DisplayTitle = "Prince of Peace",Description = "Prince of Peace",Order = 34,AdditionalInfoRequired=false,},
            new IntroMethod {Id=91,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "Providence Reformed Church",DisplayTitle = "Providence Reformed Church",Description = "Providence Reformed Church",Order = 35,AdditionalInfoRequired=false,},
            new IntroMethod {Id=92,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "Remnant Ministries",DisplayTitle = "Remnant Ministries",Description = "Remnant Ministries",Order = 36,AdditionalInfoRequired=false,},
            new IntroMethod {Id=93,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "Shadow Hills Church",DisplayTitle = "Shadow Hills Church",Description = "Shadow Hills Church",Order = 37,AdditionalInfoRequired=false,},
            new IntroMethod {Id=94,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "South Hills Church Community",DisplayTitle = "South Hills Church Community",Description = "South Hills Church Community",Order = 38,AdditionalInfoRequired=false,},
            new IntroMethod {Id=95,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "Southern Hills Baptist Church",DisplayTitle = "Southern Hills Baptist Church",Description = "Southern Hills Baptist Church",Order = 39,AdditionalInfoRequired=false,},
            new IntroMethod {Id=96,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "Spring Valley Baptist Church",DisplayTitle = "Spring Valley Baptist Church",Description = "Spring Valley Baptist Church",Order = 40,AdditionalInfoRequired=false,},
            new IntroMethod {Id=97,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "St. Anthony of Padua Catholic Church",DisplayTitle = "St. Anthony of Padua Catholic Church",Description = "St. Anthony of Padua Catholic Church",Order = 41,AdditionalInfoRequired=false,},
            new IntroMethod {Id=98,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "St. Bridget Catholic Church",DisplayTitle = "St. Bridget Catholic Church",Description = "St. Bridget Catholic Church",Order = 42,AdditionalInfoRequired=false,},
            new IntroMethod {Id=99,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "St. Francis of Assisi Catholic Church",DisplayTitle = "St. Francis of Assisi Catholic Church",Description = "St. Francis of Assisi Catholic Church",Order = 43,AdditionalInfoRequired=false,},
            new IntroMethod {Id=100,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "St. John Neumann Roman Catholic Church",DisplayTitle = "St. John Neumann Roman Catholic Church",Description = "St. John Neumann Roman Catholic Church",Order = 44,AdditionalInfoRequired=false,},
            new IntroMethod {Id=101,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "St. Joseph Husband of Mary Catholic Church",DisplayTitle = "St. Joseph Husband of Mary Catholic Church",Description = "St. Joseph Husband of Mary Catholic Church",Order = 45,AdditionalInfoRequired=false,},
            new IntroMethod {Id=102,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "St. Thomas Moore Catholic Church",DisplayTitle = "St. Thomas Moore Catholic Church",Description = "St. Thomas Moore Catholic Church",Order = 46,AdditionalInfoRequired=false,},
            new IntroMethod {Id=103,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "St. Viator's",DisplayTitle = "St. Viator's",Description = "St. Viator's",Order = 47,AdditionalInfoRequired=false,},
            new IntroMethod {Id=104,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "Summerlin Community Church",DisplayTitle = "Summerlin Community Church",Description = "Summerlin Community Church",Order = 48,AdditionalInfoRequired=false,},
            new IntroMethod {Id=105,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "The Church @ Lake Mead",DisplayTitle = "The Church @ Lake Mead",Description = "The Church @ Lake Mead",Order = 49,AdditionalInfoRequired=false,},
            new IntroMethod {Id=106,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "The Church Las Vegas",DisplayTitle = "The Church Las Vegas",Description = "The Church Las Vegas",Order = 50,AdditionalInfoRequired=false,},
            new IntroMethod {Id=107,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "The Crossing Church",DisplayTitle = "The Crossing Church",Description = "The Crossing Church",Order = 51,AdditionalInfoRequired=false,},
            new IntroMethod {Id=108,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "The River A Christian Church",DisplayTitle = "The River A Christian Church",Description = "The River A Christian Church",Order = 52,AdditionalInfoRequired=false,},
            new IntroMethod {Id=109,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "Trinity Life",DisplayTitle = "Trinity Life",Description = "Trinity Life",Order = 53,AdditionalInfoRequired=false,},
            new IntroMethod {Id=110,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "Trinity Life",DisplayTitle = "Trinity Life",Description = "Trinity Life",Order = 54,AdditionalInfoRequired=false,},
            new IntroMethod {Id=111,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "Twin Lakes Baptist Church",DisplayTitle = "Twin Lakes Baptist Church",Description = "Twin Lakes Baptist Church",Order = 55,AdditionalInfoRequired=false,},
            new IntroMethod {Id=112,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "Valley Vegas Church",DisplayTitle = "Valley Vegas Church",Description = "Valley Vegas Church",Order = 56,AdditionalInfoRequired=false,},
            new IntroMethod {Id=113,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "Wagon Wheel Missionary Baptist",DisplayTitle = "Wagon Wheel Missionary Baptist",Description = "Wagon Wheel Missionary Baptist",Order = 57,AdditionalInfoRequired=false,},
            new IntroMethod {Id=114,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "Word of Life",DisplayTitle = "Word of Life",Description = "Word of Life",Order = 58,AdditionalInfoRequired=false,},
            new IntroMethod {Id=115,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "Calvary Chapel Las Vegas",DisplayTitle = "Calvary Chapel Las Vegas",Description = "Calvary Chapel Las Vegas",Order = 59,AdditionalInfoRequired=false,},
            new IntroMethod {Id=116,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "Calvary Chapel Lone Mountain",DisplayTitle = "Calvary Chapel Lone Mountain",Description = "Calvary Chapel Lone Mountain",Order = 60,AdditionalInfoRequired=false,},
            new IntroMethod {Id=117,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "Calvary Chapel Henderson",DisplayTitle = "Calvary Chapel Henderson",Description = "Calvary Chapel Henderson",Order = 61,AdditionalInfoRequired=false,},
            new IntroMethod {Id=118,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "Calvary Chapel Boulder City",DisplayTitle = "Calvary Chapel Boulder City",Description = "Calvary Chapel Boulder City",Order = 62,AdditionalInfoRequired=false,},
            new IntroMethod {Id=119,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "Cornerstone Church",DisplayTitle = "Cornerstone Church",Description = "Cornerstone Church",Order = 63,AdditionalInfoRequired=false,},
            new IntroMethod {Id=120,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "Canyon Ridge Church",DisplayTitle = "Canyon Ridge Church",Description = "Canyon Ridge Church",Order = 64,AdditionalInfoRequired=false,},
            new IntroMethod {Id=121,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "Oasis Church",DisplayTitle = "Oasis Church",Description = "Oasis Church",Order = 65,AdditionalInfoRequired=false,},
            new IntroMethod {Id=122,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "Life Church",DisplayTitle = "Life Church",Description = "Life Church",Order = 66,AdditionalInfoRequired=false,},
            new IntroMethod {Id=123,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "Hope Church",DisplayTitle = "Hope Church",Description = "Hope Church",Order = 67,AdditionalInfoRequired=false,},
            new IntroMethod {Id=124,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "Meadow Mesa",DisplayTitle = "Meadow Mesa",Description = "Meadow Mesa",Order = 68,AdditionalInfoRequired=false,},
            new IntroMethod {Id=125,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "Walk Church",DisplayTitle = "Walk Church",Description = "Walk Church",Order = 69,AdditionalInfoRequired=false,},
            new IntroMethod {Id=126,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "The Crossing",DisplayTitle = "The Crossing",Description = "The Crossing",Order = 70,AdditionalInfoRequired=false,},
            new IntroMethod {Id=127,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "Bethany Baptist",DisplayTitle = "Bethany Baptist",Description = "Bethany Baptist",Order = 71,AdditionalInfoRequired=false,},
            new IntroMethod {Id=128,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "Faith Lutheran",DisplayTitle = "Faith Lutheran",Description = "Faith Lutheran",Order = 72,AdditionalInfoRequired=false,},
            new IntroMethod {Id=129,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "St. Joseph Husband of Mary",DisplayTitle = "St. Joseph Husband of Mary",Description = "St. Joseph Husband of Mary",Order = 73,AdditionalInfoRequired=false,},
            new IntroMethod {Id=130,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "St Thomas Moore",DisplayTitle = "St Thomas Moore",Description = "St Thomas Moore",Order = 74,AdditionalInfoRequired=false,},
            new IntroMethod {Id=131,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "St. Frances Assisi",DisplayTitle = "St. Frances Assisi",Description = "St. Frances Assisi",Order = 75,AdditionalInfoRequired=false,},
            new IntroMethod {Id=132,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "Grace Point",DisplayTitle = "Grace Point",Description = "Grace Point",Order = 76,AdditionalInfoRequired=false,},
            new IntroMethod {Id=133,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "Grace Bible Fellowship",DisplayTitle = "Grace Bible Fellowship",Description = "Grace Bible Fellowship",Order = 77,AdditionalInfoRequired=false,},
            new IntroMethod {Id=134,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "Anthem Church",DisplayTitle = "Anthem Church",Description = "Anthem Church",Order = 78,AdditionalInfoRequired=false,},
            new IntroMethod {Id=135,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "Green Valley Baptist",DisplayTitle = "Green Valley Baptist",Description = "Green Valley Baptist",Order = 79,AdditionalInfoRequired=false,},
            new IntroMethod {Id=136,ParentId = 14,Type = TreeTypeEnum.Leaf,Name = "Other",DisplayTitle = "Other",Description = "Other",Order = 80,AdditionalInfoRequired=false,},
            //Parent : AbortionClinic
            new IntroMethod {Id=137,ParentId = 15,Type = TreeTypeEnum.Leaf,Name = "Planned Parenthood",DisplayTitle = "Planned Parenthood",Description = "Planned Parenthood",Order = 1,AdditionalInfoRequired=false,},
            new IntroMethod {Id=138,ParentId = 15,Type = TreeTypeEnum.Leaf,Name = "Birth Control Center",DisplayTitle = "Birth Control Center",Description = "Birth Control Center",Order = 2,AdditionalInfoRequired=false,},
            new IntroMethod {Id=139,ParentId = 15,Type = TreeTypeEnum.Leaf,Name = "Other",DisplayTitle = "Other",Description = "Other",Order = 3,AdditionalInfoRequired=false,},
        
        };
    }
}
