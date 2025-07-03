import './App.css'
import {BrowserRouter, Route, Routes} from "react-router";
import Payments from "./Components/Payments.tsx";
import Home from "./Components/Home.tsx";
import ParkingAreas from "./Components/ParkingAreas.tsx";


function App() {
  return (
    <>
        <BrowserRouter>
            <Routes>
                <Route path="/" element={<Home />} />
                <Route path="/parking-areas" element={<ParkingAreas />} />
                <Route path="/payments" element={<Payments />} />
            </Routes>
        </BrowserRouter>
    </>
  )
}

export default App
