export interface ParkingArea {
    id?: string;
    name: string;
    weekdayHourlyRate: number;
    weekendHourlyRate: number;
    discountPercentage: number;
}