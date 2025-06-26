import { useState, useEffect } from 'react'
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';

interface ParkingArea {
  id: string;
  name: string;
  weekdayHourlyRate: number;
  weekendHourlyRate: number;
  discountPercentage: number;
}

const ParkingArea = () => {
  const [parkingAreas, setParkingAreas] = useState<ParkingArea[]>([]);

  useEffect(() => {
    const fetchAreas = async () => {
      const response = await fetch('http://localhost:5000/parking-areas');

      const data: ParkingArea[] = await response.json();
      setParkingAreas(data);
    };

    fetchAreas();
  }, []);

  return(
    <>
        <TableContainer component={Paper}>
          <Table>
            <TableHead>
              <TableRow>
                <TableCell>Parking Area</TableCell>
                <TableCell>Weekday Hourly Rate</TableCell>
                <TableCell>Weekend Hourly Rate</TableCell>
                <TableCell>Discount Percentage</TableCell>
                <TableCell>Actions</TableCell>
              </TableRow>
            </TableHead>
            <TableBody>
              {parkingAreas.map((area: ParkingArea, index: number) => (
                <TableRow key={index}>
                  <TableCell>{area.name}</TableCell>
                  <TableCell>{area.weekdayHourlyRate}</TableCell>
                  <TableCell>{area.weekendHourlyRate}</TableCell>
                  <TableCell>{area.discountPercentage}</TableCell>
                  <TableCell>
                    <button>Edit</button>
                    <button>Delete</button>
                  </TableCell>
                </TableRow>
              ))}        
            </TableBody>
          </Table>
        </TableContainer>
    </>
  )
}

export default ParkingArea
