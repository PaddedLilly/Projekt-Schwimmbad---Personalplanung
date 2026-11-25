**Zur Erstellung des Projekts wurde sporadisch Chat-GPT verwendet.**
**Nur in wenigen Fällen habe ich tatsächlich KI generierten Code verwendet. Einige Beispiele:**

**Prompt1**
    CREATE TABLE Mitarbeiter (
        MitarbeiterID   int PRIMARY KEY IDENTITY (1,1),
        MitarbeiterName varchar(50),
        ArbeitsStunden  int,
        ArbeitsTypID    int --TODO FOREIGN KEY
    );

    CREATE TABLE Schicht (
        SchichtID   int PRIMARY KEY IDENTITY (1,1),
        SchichtName varchar(50),
        BeginZeit   datetime,
        EndZeit     datetime,
    );

    CREATE TABLE Besetzung (
        MitarbeiterID   int, --TODO FOREIGN KEY
        SchichtID       int, --TODO FOREIGN KEY
    );

    CREATE TABLE ArbeitsTyp (
        ArbeitsTypID    int PRIMARY KEY IDENTITY (1,1),
        Bezeichnung     varchar(50),
    );

    CREATE TABLE PersonalBedarf (
        ArbeitsTypID    int, --TODO FOREIGN KEY
        SchichtID       int, --TODO FOREIGN KEY
    );

    You can you insert the foreign keys in the marked areas ples :3

**response 1** genau so im code verwendet
    Of course :3 I've inserted the foreign keys in the marked places and also fixed the trailing commas that would otherwise cause SQL Server syntax errors.

    CREATE TABLE Mitarbeiter (
        MitarbeiterID   int PRIMARY KEY IDENTITY (1,1),
        MitarbeiterName varchar(50),
        ArbeitsStunden  int,
        ArbeitsTypID    int,
        FOREIGN KEY (ArbeitsTypID) REFERENCES ArbeitsTyp(ArbeitsTypID)
    );

    CREATE TABLE Schicht (
        SchichtID   int PRIMARY KEY IDENTITY (1,1),
        SchichtName varchar(50),
        BeginZeit   datetime,
        EndZeit     datetime
    );

    CREATE TABLE Besetzung (
        MitarbeiterID   int,
        SchichtID       int,
        FOREIGN KEY (MitarbeiterID) REFERENCES Mitarbeiter(MitarbeiterID),
        FOREIGN KEY (SchichtID) REFERENCES Schicht(SchichtID)
    );

    CREATE TABLE ArbeitsTyp (
        ArbeitsTypID    int PRIMARY KEY IDENTITY (1,1),
        Bezeichnung     varchar(50)
    );

    CREATE TABLE PersonalBedarf (
        ArbeitsTypID    int,
        SchichtID       int,
        FOREIGN KEY (ArbeitsTypID) REFERENCES ArbeitsTyp(ArbeitsTypID),
        FOREIGN KEY (SchichtID) REFERENCES Schicht(SchichtID)
    );

    One important thing: SQL Server requires referenced tables to exist before you create foreign keys pointing to them.

    So your creation order should actually be:

        ArbeitsTyp

        Mitarbeiter

        Schicht

        Besetzung

        PersonalBedarf

    Also, I'd recommend adding a composite primary key to Besetzung and PersonalBedarf:

    PRIMARY KEY (MitarbeiterID, SchichtID)

    and

    PRIMARY KEY (ArbeitsTypID, SchichtID)

    That prevents duplicate assignments and duplicate staffing requirements. Otherwise, your database could happily assign the same employee to the same shift twice. SQL is very obedient, sometimes too obedient. :3

**Prompt 2**
    ('Peter Kleber',    40, 1),
    ('Willy Weber',     30, 2);

    Das sind SQL daten, mach mal mehrere daraus. Die erste zahl ist arbeitszeit, die zweite ist arbeitstyp von 1-5 


**response 2** genau so verwendet
    ('Peter Kleber',    40, 1),
    ('Willy Weber',     30, 2),
    ('Hans Müller',     35, 3),
    ('Klaus Schmidt',   40, 1),
    ('Sabine Fischer',  25, 4),
    ('Monika Schneider',30, 2),
    ('Thomas Becker',   38, 5),
    ('Uwe Hoffmann',    20, 3),
    [...]

**In diesen beiden Beispielen habe ich KI schicht aus Bequemlichkeit benutzt**
**Das nächste Beispiel ist komplizierter:**

**promt 3**
    Can you compress this c# code for me? It has a lot of redundancy 

    //read out personalbedarf
                List<int> personalbedarf = new();
                while (personalbedarf.Count == 0)
                {
                    Console.Clear();
                    Console.WriteLine("Wieviele Fachangestellte für Bäderbetriebe werden benötigt?");
                    try {personalbedarf.Add(Convert.ToInt32(Console.ReadLine()));}
                    catch (FormatException e)
                    {
                        Console.Clear();
                        Console.Write("Fehlerhafte Eingabe. Int erwartet");
                        Console.ReadLine();
                    }
                }
                
                while (personalbedarf.Count == 1)
                {
                    Console.Clear();
                    Console.WriteLine("Wieviele Verwaltungsfachkräfte werden benötigt?");
                    try {personalbedarf.Add( Convert.ToInt32(Console.ReadLine()) ); }
                    catch (FormatException e)
                    {
                        Console.Clear();
                        Console.Write("Fehlerhafte Eingabe. Int erwartet");
                        Console.ReadLine();
                    }
                }
    [5 iterationen hiervon...]

**answer 3**
    Absolutely! You can replace the entire thing with a simple array of names and a foreach loop.
    List<int> personalbedarf = new();

    string[] personaltypen =
    {
        "Fachangestellte für Bäderbetriebe",
        "Verwaltungsfachkräfte",
        "Arbeiter im Empfang",
        "Reinigungsfachkräfte",
        "Hausmeister"
    };

    foreach (string typ in personaltypen)
    {
        while (true)
        {
            Console.Clear();
            Console.WriteLine($"Wieviele {typ} werden benötigt?");

            try
            {
                personalbedarf.Add(Convert.ToInt32(Console.ReadLine()));
                break;
            }
            catch (FormatException)
            {
                Console.Clear();
                Console.Write("Fehlerhafte Eingabe. Int erwartet");
                Console.ReadLine();
            }
        }
    }


**In einem weiteren Fall habe ich Chat-GPT ein Konzept für den Aufbau der verwendeten Datenbank generieren lassen.**
**Dies hab ich erst gemacht, nachdem ich die Datenbank selbst modeliert hatte um zu sehen ob es zu einem vergleichbaren Ergebniss kommt, was auch der Fall war.**
**Kein KI generierter Code wurde modifiziert verwendet oder verworfen.**
**Da ich nicht viel mit KI generiertem Code gearbeitet habe, kann ich nicht wirklich viel über meine Lernerfahrung sagen.**
**Bei Beispiel 1 hab ich mir erspart mich mit Foreign Keys zu beschäftigen und dementsprechend nix gelernt.**
**Auf die Lösung von Prompt 3 hätte ich wohl besser selbst kommen sollen, das hätte mir einiges tippen erspart...**
