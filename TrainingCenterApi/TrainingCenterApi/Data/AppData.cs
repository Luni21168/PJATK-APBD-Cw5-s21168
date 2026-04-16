using TrainingCenterApi.Models;

namespace TrainingCenterApi.Data;

public static class AppData
{
    public static List<Room> Rooms { get; } =
    [
        new Room
        {
            Id = 1,
            Name = "Lab 101",
            BuildingCode = "A",
            Floor = 1,
            Capacity = 20,
            HasProjector = true,
            IsActive = true
        },
        new Room
        {
            Id = 2,
            Name = "Lab 204",
            BuildingCode = "B",
            Floor = 2,
            Capacity = 24,
            HasProjector = true,
            IsActive = true
        },
        new Room
        {
            Id = 3,
            Name = "Consultation Room",
            BuildingCode = "A",
            Floor = 1,
            Capacity = 8,
            HasProjector = false,
            IsActive = true
        },
        new Room
        {
            Id = 4,
            Name = "Workshop Hall",
            BuildingCode = "C",
            Floor = 0,
            Capacity = 60,
            HasProjector = true,
            IsActive = true
        },
        new Room
        {
            Id = 5,
            Name = "Old Room",
            BuildingCode = "B",
            Floor = 3,
            Capacity = 15,
            HasProjector = false,
            IsActive = false
        }
    ];

    public static List<Reservation> Reservations { get; } =
    [
        new Reservation
        {
            Id = 1,
            RoomId = 1,
            OrganizerName = "Anna Kowalska",
            Topic = "Warsztaty z HTTP",
            Date = new DateOnly(2026, 5, 10),
            StartTime = new TimeOnly(10, 0),
            EndTime = new TimeOnly(12, 30),
            Status = "confirmed"
        },
        new Reservation
        {
            Id = 2,
            RoomId = 2,
            OrganizerName = "Jan Nowak",
            Topic = "REST API basics",
            Date = new DateOnly(2026, 5, 10),
            StartTime = new TimeOnly(13, 0),
            EndTime = new TimeOnly(15, 0),
            Status = "planned"
        },
        new Reservation
        {
            Id = 3,
            RoomId = 4,
            OrganizerName = "Maria Zielinska",
            Topic = "Cloud workshop",
            Date = new DateOnly(2026, 5, 12),
            StartTime = new TimeOnly(9, 0),
            EndTime = new TimeOnly(11, 0),
            Status = "confirmed"
        },
        new Reservation
        {
            Id = 4,
            RoomId = 3,
            OrganizerName = "Piotr Lis",
            Topic = "Consultations",
            Date = new DateOnly(2026, 5, 15),
            StartTime = new TimeOnly(14, 0),
            EndTime = new TimeOnly(15, 30),
            Status = "cancelled"
        }
    ];
}