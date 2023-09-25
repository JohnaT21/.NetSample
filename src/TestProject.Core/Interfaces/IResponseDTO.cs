namespace TestProject.Core.Interfaces;

public interface IResponseDTO
{
    bool IsPassed { get; set; }
    string Message { get; set; }
    dynamic Data { get; set; }

}

public interface IStockQuantityResponseDTO
{
    int Quantity { get; set; }

}

public interface IInvetoryRequestResponseDTO
{
    int? Quantity { get; set; }
    string? Name { get; set; }
    Guid? StoreId { get; set; }

    Guid? EquipmentId { get; set; }

    Guid? SparePartId { get; set; }

    string? ItemType { get; set; }

    // dynamic Stores { get; set; }


}
