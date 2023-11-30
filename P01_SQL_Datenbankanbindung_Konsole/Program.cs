using Microsoft.Data.Sqlite;
using System;

namespace P01_SQL_Datenbankanbindung_Konsole
{
    internal class Program
    {
        static void Main()
        {
            try
            {
                string connectionString = "Data Source=sample.db";

                // Verbindung zur SQLite Datenbank herstellen
                using (var connection = new SqliteConnection(connectionString))
                {
                    connection.Open();

                    // Tabelle erstellen (wenn nicht vorhanden)
                    using (var command = connection.CreateCommand())
                    {
                        // SQL-Befehl zum Erstellen der Tabelle Persons
                        command.CommandText = "CREATE TABLE IF NOT EXISTS Persons (Id INTEGER PRIMARY KEY, Name TEXT)";
                        command.ExecuteNonQuery();
                    }

                    while (true)
                    {
                        Console.Clear();

                        // Menü in der Konsole
                        Console.WriteLine("1. Daten lesen");
                        Console.WriteLine("2. Daten hinzufügen");
                        Console.WriteLine("3. Daten löschen");
                        Console.WriteLine("4. Beenden");

                        // Benutzereingabe lesen
                        Console.Write("Auswahl: ");
                        string input = Console.ReadLine();

                        // switch case für die Usereingabe
                        switch (input)
                        {
                            case "1":
                                Console.Clear();
                                Console.WriteLine("Daten lesen:");
                                ReadData(connection);
                                break;

                            case "2":
                                Console.Clear();
                                Console.WriteLine("Daten hinzufügen:");
                                Console.Write("Name eingeben: ");
                                string nameToAdd = Console.ReadLine();
                                InsertData(connection, nameToAdd);
                                break;

                            case "3":
                                Console.Clear();
                                Console.WriteLine("Daten löschen:");
                                Console.Write("ID zum Löschen eingeben: ");
                                if (int.TryParse(Console.ReadLine(), out int idToDelete))
                                {
                                    DeleteData(connection, idToDelete);
                                }
                                else
                                {
                                    Console.WriteLine("Ungültige Eingabe. ID muss eine ganze Zahl sein.");
                                }
                                break;

                            case "4":
                                Console.WriteLine("Programm wird beendet.");
                                return;

                            default:
                                Console.WriteLine("Ungültige Eingabe. Bitte wählen Sie 1, 2, 3 oder 4");
                                break;
                        }

                        // Wartemenü
                        Console.WriteLine("\nDrücken Sie eine beliebige Taste, um fortzufahren...");
                        Console.ReadKey();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Fehler: {ex.Message}");
            }
        }

        static void InsertData(SqliteConnection connection, string name)
        {
            using (var command = connection.CreateCommand())
            {
                // SQLBefehl zum Einfügen von Daten in die Tabelle Persons
                command.CommandText = "INSERT INTO Persons (Name) VALUES (@Name)";
                command.Parameters.AddWithValue("@Name", name); // Parameter hinzufügen
                command.ExecuteNonQuery();
                Console.WriteLine("Daten wurden hinzugefügt.");
            }
        }

        static void DeleteData(SqliteConnection connection, int id)
        {
            using (var command = connection.CreateCommand())
            {
                // SQL-Befehl zum Löschen von Daten aus Persons
                command.CommandText = "DELETE FROM Persons WHERE Id = @Id";
                command.Parameters.AddWithValue("@Id", id); // Parameter hinzufügen bzw. entfernen
                int rowsAffected = command.ExecuteNonQuery(); 
                if (rowsAffected > 0)
                {
                    Console.WriteLine("Daten wurden gelöscht.");
                }
                else
                {
                    Console.WriteLine("Keine Daten gefunden, die gelöscht werden können.");
                }
            }
        }

        static void ReadData(SqliteConnection connection)
        {
            using (var command = connection.CreateCommand())
            {
                // SQL-B. zum Auswählen aller Daten aus Persons
                command.CommandText = "SELECT * FROM Persons";

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        // Infos aus der Resulttabelle(Datenbank) holen und ausgeben
                        Console.WriteLine($"Id: {reader.GetInt32(0)}, Name: {reader.GetString(1)}");
                    }
                }
            }
        }
    }
}


