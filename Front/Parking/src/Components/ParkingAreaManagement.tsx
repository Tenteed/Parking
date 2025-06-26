import ParkingArea from './ParkingArea';
import TextField from '@mui/material/TextField';

const ParkingAreaManagement = () => {
  

  return (
    <>
      <button>Create</button>
      <TextField variant="standard" label="Name" />
      <TextField variant="standard" label="Weekday rate" />
      <TextField variant="standard" label="Weekend rate" />
      <TextField variant="standard" label="Discount percentage" />
      <ParkingArea />
    </>
  )
}

export default ParkingAreaManagement
