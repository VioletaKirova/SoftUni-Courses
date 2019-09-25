namespace _04_HotelReservation
{
    public static class PriceCalculator
    {
        public static decimal CalcHolidayPrice(decimal pricePerDay, int days, Season season, DiscountType discount)
        {
            decimal price = days * pricePerDay * (int)season;
            price -= price * ((decimal)discount / 100);

            return price;
        }
    }
}
