import type { Component } from 'solid-js';

import logo from './logo.svg';
import styles from './App.module.css';
import { createResource, createSignal, For } from 'solid-js';
import { Flex } from './components/ui/flex';
import { Switch, SwitchControl, SwitchLabel, SwitchThumb } from './components/ui/switch';
import { TextField, TextFieldInput, TextFieldLabel } from './components/ui/text-field';
import Navbar from './Navbar';

import Stock from './models/Stock';

const App: Component = () => {
  const [weatherLocation, setWeatherLocation] = createSignal('London')
  const [weather] = createResource(weatherLocation, (location) => fetch(`/api/weatherforecast?location=${location}`).then(res => res.json()))

  const [TableData, SetTableData] = createSignal()
  const [stockData] = createResource(() => fetch('stocks').then(result => result.json()))
  

  async function FetchStockData(params:Stock) : Promise<Stock[]> {
    const stockItems:Stock[] = [];

    try {
      const response = await fetch('https://localhost:42069/stocks');
      if(!response.ok){
        throw new Error("Failed to fetch stock items");
      }

      return await response.json();

    } catch (error) {
      console.error("Error fetching stock names:", error);
      return [];
    }
  }

  return (
    <Flex flexDirection='col' alignItems='center' justifyContent='center' class="gap-2 my-2">

      {/* ------------ Page Title on the top left and Navbar in the top middle ------------ */}
      <Flex flexDirection='row' alignItems='center' justifyContent='start'>
        <h1>CarPartWarehouse Dashboard</h1>

        <Flex flexDirection='row' alignItems='center' justifyContent='center'>
          <Navbar/>
        </Flex>
      </Flex>
      {/* -------------------------------------------------------------------------------- */}

      <p>{stockData()}</p>
      
    </Flex>
  );
};

export default App;
