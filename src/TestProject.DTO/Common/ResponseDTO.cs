using TestProject.Core.Interfaces;

namespace TestProject.DTO.Common;

public class ResponseDTO : IResponseDTO
{
    public ResponseDTO()
    {
        IsPassed = false;
        Message = "";
    }
    public bool IsPassed { get; set; }

    public string Message { get; set; }

    public dynamic Data { get; set; }

    public void Copy(ResponseDTO x)
    {
        IsPassed = x.IsPassed;
        Message = x.Message;
        Data = x.Data;
    }
}

public class StockQuantityResponseDTO : IStockQuantityResponseDTO

{
    public StockQuantityResponseDTO()
    {
    }
    public int Quantity { get; set; }

    public void Copy(StockQuantityResponseDTO x)
    {

        Quantity = x.Quantity;
    }
}

public class InvetoryRequestResponseDTO : IInvetoryRequestResponseDTO

{
    public InvetoryRequestResponseDTO()
    {
    }

    public int? Quantity { get; set; }
    public string? Name { get; set; }
    public Guid? StoreId { get; set; }

    public Guid? EquipmentId { get; set; }

   public Guid? SparePartId { get; set; }

    public string? ItemType { get; set; }

    // public  dynamic Stores { get; set; }

    public void Copy(InvetoryRequestResponseDTO x)
    {
        Quantity = x.Quantity;
        Name = x.Name;
        StoreId = x.StoreId;
        EquipmentId = x.EquipmentId;
        SparePartId = x.SparePartId;
        ItemType = x.ItemType;
    }
}
