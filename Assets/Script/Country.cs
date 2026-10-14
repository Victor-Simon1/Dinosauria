using UnityEngine;

public enum ECountry
{
    AF, // Afghanistan
    AL, // Albania
    DZ, // Algeria
    AD, // Andorra
    AO, // Angola
    AG, // Antigua and Barbuda
    AR, // Argentina
    AM, // Armenia
    AU, // Australia
    AT, // Austria
    AZ, // Azerbaijan

    BS, // Bahamas
    BH, // Bahrain
    BD, // Bangladesh
    BB, // Barbados
    BY, // Belarus
    BE, // Belgium
    BZ, // Belize
    BJ, // Benin
    BT, // Bhutan
    BO, // Bolivia
    BA, // Bosnia and Herzegovina
    BW, // Botswana
    BR, // Brazil
    BN, // Brunei
    BG, // Bulgaria
    BF, // Burkina Faso
    BI, // Burundi

    KH, // Cambodia
    CM, // Cameroon
    CA, // Canada
    CV, // Cape Verde
    CF, // Central African Republic
    TD, // Chad
    CL, // Chile
    CN, // China
    CO, // Colombia
    KM, // Comoros
    CG, // Congo
    CD, // Democratic Republic of the Congo
    CR, // Costa Rica
    HR, // Croatia
    CU, // Cuba
    CY, // Cyprus
    CZ, // Czechia

    DK, // Denmark
    DJ, // Djibouti
    DM, // Dominica
    DO, // Dominican Republic

    EC, // Ecuador
    EG, // Egypt
    SV, // El Salvador
    GQ, // Equatorial Guinea
    ER, // Eritrea
    EE, // Estonia
    SZ, // Eswatini
    ET, // Ethiopia

    FJ, // Fiji
    FI, // Finland
    FR, // France

    GA, // Gabon
    GM, // Gambia
    GE, // Georgia
    DE, // Germany
    GH, // Ghana
    GR, // Greece
    GD, // Grenada
    GT, // Guatemala
    GN, // Guinea
    GW, // Guinea-Bissau
    GY, // Guyana

    HT, // Haiti
    HN, // Honduras
    HU, // Hungary

    IS, // Iceland
    IN, // India
    ID, // Indonesia
    IR, // Iran
    IQ, // Iraq
    IE, // Ireland
    IL, // Israel
    IT, // Italy

    JM, // Jamaica
    JP, // Japan
    JO, // Jordan

    KZ, // Kazakhstan
    KE, // Kenya
    KI, // Kiribati
    KP, // North Korea
    KR, // South Korea
    KW, // Kuwait
    KG, // Kyrgyzstan

    LA, // Laos
    LV, // Latvia
    LB, // Lebanon
    LS, // Lesotho
    LR, // Liberia
    LY, // Libya
    LI, // Liechtenstein
    LT, // Lithuania
    LU, // Luxembourg

    MG, // Madagascar
    MW, // Malawi
    MY, // Malaysia
    MV, // Maldives
    ML, // Mali
    MT, // Malta
    MH, // Marshall Islands
    MR, // Mauritania
    MU, // Mauritius
    MX, // Mexico
    FM, // Micronesia
    MD, // Moldova
    MC, // Monaco
    MN, // Mongolia
    ME, // Montenegro
    MA, // Morocco
    MZ, // Mozambique
    MM, // Myanmar

    NA, // Namibia
    NR, // Nauru
    NP, // Nepal
    NL, // Netherlands
    NZ, // New Zealand
    NI, // Nicaragua
    NE, // Niger
    NG, // Nigeria
    MK, // North Macedonia
    NO, // Norway

    OM, // Oman

    PK, // Pakistan
    PW, // Palau
    PA, // Panama
    PG, // Papua New Guinea
    PY, // Paraguay
    PE, // Peru
    PH, // Philippines
    PL, // Poland
    PT, // Portugal

    QA, // Qatar

    RO, // Romania
    RU, // Russia
    RW, // Rwanda

    KN, // Saint Kitts and Nevis
    LC, // Saint Lucia
    VC, // Saint Vincent and the Grenadines
    WS, // Samoa
    SM, // San Marino
    ST, // Sao Tome and Principe
    SA, // Saudi Arabia
    SN, // Senegal
    RS, // Serbia
    SC, // Seychelles
    SL, // Sierra Leone
    SG, // Singapore
    SK, // Slovakia
    SI, // Slovenia
    SB, // Solomon Islands
    SO, // Somalia
    ZA, // South Africa
    ES, // Spain
    LK, // Sri Lanka
    SD, // Sudan
    SS, // South Sudan
    SR, // Suriname
    SE, // Sweden
    CH, // Switzerland
    SY, // Syria

    TW, // Taiwan
    TJ, // Tajikistan
    TZ, // Tanzania
    TH, // Thailand
    TL, // Timor-Leste
    TG, // Togo
    TO, // Tonga
    TT, // Trinidad and Tobago
    TN, // Tunisia
    TR, // Turkey
    TM, // Turkmenistan
    TV, // Tuvalu

    UG, // Uganda
    UA, // Ukraine
    AE, // United Arab Emirates
    GB, // United Kingdom
    US, // United States
    UY, // Uruguay
    UZ, // Uzbekistan

    VU, // Vanuatu
    VA, // Vatican City
    VE, // Venezuela
    VN, // Vietnam

    YE, // Yemen

    ZM, // Zambia
    ZW  // Zimbabwe
}

public enum Continent

{
    Africa,
    Antarctica,
    Asia,
    Europe,
    NorthAmerica,
    SouthAmerica,
    Oceania
}


public static class ECountryExtensions
{
    public static Continent GetContinent(this ECountry country)
    {
        return country switch
        {
            // Europe
            ECountry.FR => Continent.Europe,
            ECountry.DE => Continent.Europe,
            ECountry.IT => Continent.Europe,
            ECountry.ES => Continent.Europe,
            ECountry.GB => Continent.Europe,
            ECountry.BE => Continent.Europe,
            ECountry.NL => Continent.Europe,
            ECountry.CH => Continent.Europe,
            ECountry.AT => Continent.Europe,
            ECountry.SE => Continent.Europe,
            ECountry.NO => Continent.Europe,
            ECountry.DK => Continent.Europe,
            ECountry.FI => Continent.Europe,
            ECountry.PL => Continent.Europe,
            ECountry.CZ => Continent.Europe,
            ECountry.SK => Continent.Europe,
            ECountry.HU => Continent.Europe,
            ECountry.RO => Continent.Europe,
            ECountry.BG => Continent.Europe,
            ECountry.GR => Continent.Europe,
            ECountry.PT => Continent.Europe,
            ECountry.IE => Continent.Europe,
            ECountry.UA => Continent.Europe,
            ECountry.RU => Continent.Europe,
            ECountry.RS => Continent.Europe,
            ECountry.HR => Continent.Europe,
            ECountry.SI => Continent.Europe,
            ECountry.LU => Continent.Europe,
            ECountry.MC => Continent.Europe,
            ECountry.AD => Continent.Europe,
            ECountry.SM => Continent.Europe,
            ECountry.VA => Continent.Europe,

            // Afrique
            ECountry.DZ => Continent.Africa,
            ECountry.MA => Continent.Africa,
            ECountry.TN => Continent.Africa,
            ECountry.EG => Continent.Africa,
            ECountry.SN => Continent.Africa,
            //ECountry.CI => Continent.Africa,
            ECountry.GH => Continent.Africa,
            ECountry.NG => Continent.Africa,
            ECountry.KE => Continent.Africa,
            ECountry.ZA => Continent.Africa,
            ECountry.ET => Continent.Africa,
            ECountry.TZ => Continent.Africa,
            ECountry.UG => Continent.Africa,

            // Asie
            ECountry.CN => Continent.Asia,
            ECountry.JP => Continent.Asia,
            ECountry.KR => Continent.Asia,
            ECountry.KP => Continent.Asia,
            ECountry.IN => Continent.Asia,
            ECountry.PK => Continent.Asia,
            ECountry.TH => Continent.Asia,
            ECountry.VN => Continent.Asia,
            ECountry.ID => Continent.Asia,
            ECountry.SG => Continent.Asia,
            ECountry.AE => Continent.Asia,
            ECountry.SA => Continent.Asia,
            ECountry.IL => Continent.Asia,
            ECountry.TR => Continent.Asia,
            ECountry.IR => Continent.Asia,
            ECountry.IQ => Continent.Asia,

            // Amérique du Nord
            ECountry.US => Continent.NorthAmerica,
            ECountry.CA => Continent.NorthAmerica,
            ECountry.MX => Continent.NorthAmerica,
            ECountry.CU => Continent.NorthAmerica,
            ECountry.DO => Continent.NorthAmerica,
            ECountry.HT => Continent.NorthAmerica,
            ECountry.JM => Continent.NorthAmerica,
            ECountry.CR => Continent.NorthAmerica,
            ECountry.PA => Continent.NorthAmerica,

            // Amérique du Sud
            ECountry.BR => Continent.SouthAmerica,
            ECountry.AR => Continent.SouthAmerica,
            ECountry.CL => Continent.SouthAmerica,
            ECountry.PE => Continent.SouthAmerica,
            ECountry.CO => Continent.SouthAmerica,
            ECountry.VE => Continent.SouthAmerica,
            ECountry.UY => Continent.SouthAmerica,
            ECountry.PY => Continent.SouthAmerica,
            ECountry.BO => Continent.SouthAmerica,
            ECountry.EC => Continent.SouthAmerica,

            // Océanie
            ECountry.AU => Continent.Oceania,
            ECountry.NZ => Continent.Oceania,
            ECountry.FJ => Continent.Oceania,
            ECountry.PG => Continent.Oceania,

            // Antarctique
            _ => Continent.Antarctica
        };
    }

    public static Color GetColorCountry(this ECountry country)
    {
        Continent continent = GetContinent(country);
        Color colorContinent = Color.white;
        switch(continent)
        {
            case Continent.Europe:
                colorContinent = Color.blue;
                break;
            case Continent.Africa:
                colorContinent = Color.black;
                break;
            case Continent.SouthAmerica:
                colorContinent = Color.orange;
                break;
            case Continent.NorthAmerica:
                colorContinent = Color.red;
                break;
            case Continent.Asia:
                colorContinent = Color.yellow;
                break;
            case Continent.Oceania:
                colorContinent = Color.green;
                break;
            case Continent.Antarctica:
                colorContinent = Color.grey;
                break;
            default:
                colorContinent = Color.white;
                break;
        }
        return colorContinent;
    }
}

