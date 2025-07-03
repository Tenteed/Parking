import Stack from '@mui/material/Stack';
import Button from '@mui/material/Button';
import { Link } from "react-router";

const Home = () => {
    return(
        <>
            <Stack spacing={2} direction="row">
                <Link to="/parking-areas">
                    <Button variant="outlined">Parking Area Management</Button>
                </Link>
                <Link to="/payments">
                    <Button variant="outlined">Payments</Button>
                </Link>
            </Stack>
        </>
    )
}

export default Home;