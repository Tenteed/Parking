import FormControl from '@mui/material/FormControl';
import TextField from '@mui/material/TextField';
import {Box, Dialog} from "@mui/material";
import  {type FormEvent} from "react";
import Button from "@mui/material/Button";
import type {ParkingArea} from "../Shared/ParkingArea.tsx";
import * as React from "react";

const ParkingAreaManagement = () => {
    const [isOpen, setIsOpen] = React.useState(false);
    const validate = () => {
        return true;
    }
    const handleSubmit = async (e: FormEvent<HTMLFormElement>) => {
        const data = new FormData(e.currentTarget);

        const request: ParkingArea = {
            name: data.get('name') as string,
            weekdayHourlyRate: Number(data.get('weekdayRate')),
            weekendHourlyRate: Number(data.get('weekendRate')),
            discountPercentage: Number(data.get('discount')),
        };

        const requestOptions = {
            method: "POST",
            headers: { "Content-Type": "application/json" },
            body: JSON.stringify(request),
        };

        await fetch('http://localhost:5000/parking-areas',  requestOptions)
    }

    const handleOpen = () => {
        setIsOpen(true);
    }
    const handleClose = () => {
        setIsOpen(false);
    }
  return (
    <>
        <Button onClick={handleOpen}>Create new spot</Button>
        <Dialog open={isOpen} onClose={handleClose}>
            <Box
            component="form"
            onSubmit={handleSubmit}
            >
              <FormControl>
                <TextField variant="standard" label="Name" id="name" name='name' />
                  </FormControl>
              <FormControl>
                <TextField
                    variant="standard" label="Weekday rate" id="weekdayRate" name="weekdayRate" />
              </FormControl>
                <FormControl>
                  <TextField
                      variant="standard"
                      label="Weekend rate"
                      id="weekendRate"
                      name="weekendRate"
                      required={true}
                  />
                </FormControl>
              <FormControl>
                <TextField
                    variant="standard"
                    label="Discount percentage"
                    id="discount"
                    name="discount"
                />
              </FormControl>
                    <Button
                        type="submit"
                        onClick={validate}
                        variant="outlined"
                    >
                        Create
                    </Button>
                </Box>
        </Dialog>
    </>
  )
}

export default ParkingAreaManagement
