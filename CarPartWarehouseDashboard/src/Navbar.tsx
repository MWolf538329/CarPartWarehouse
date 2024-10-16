import type { Component } from 'solid-js';

import logo from './logo.svg';
import styles from './App.module.css';
import { createResource, createSignal, For } from 'solid-js';
 
import type { Orientation } from "@kobalte/core/navigation-menu"
 
import {
  NavigationMenu,
  NavigationMenuContent,
  NavigationMenuDescription,
  NavigationMenuIcon,
  NavigationMenuItem,
  NavigationMenuLabel,
  NavigationMenuLink,
  NavigationMenuTrigger
} from "~/components/ui/navigation-menu"
import { Flex } from './components/ui/flex';

const Navbar: Component = () => {
  const [weatherLocation, setWeatherLocation] = createSignal('London')
  const [weather] = createResource(weatherLocation, (location) => fetch(`/api/weatherforecast?location=${location}`).then(res => res.json()))

  return (
    <div class="flex flex-col items-center space-y-4">
      <NavigationMenu>
        <NavigationMenuItem>
          <NavigationMenuTrigger>
            Overview
            <NavigationMenuIcon />
          </NavigationMenuTrigger>
 
          <NavigationMenuContent class="grid w-[400px] gap-3 p-4 md:w-[500px] md:grid-cols-2 lg:w-[600px]">
            <NavigationMenuLink href="https://kobalte.dev/docs/core/overview/introduction">
              <NavigationMenuLabel>Introduction</NavigationMenuLabel>
              <NavigationMenuDescription>
                Build high-quality, accessible design systems and web apps.
              </NavigationMenuDescription>
            </NavigationMenuLink>
 
            <NavigationMenuLink href="https://kobalte.dev/docs/core/overview/getting-started">
              <NavigationMenuLabel>Getting started</NavigationMenuLabel>
              <NavigationMenuDescription>
                A quick tutorial to get you up and running with Kobalte.
              </NavigationMenuDescription>
            </NavigationMenuLink>
            <NavigationMenuLink href="https://kobalte.dev/docs/core/overview/styling">
              <NavigationMenuLabel>Styling</NavigationMenuLabel>
              <NavigationMenuDescription>
                Unstyled and compatible with any styling solution.
              </NavigationMenuDescription>
            </NavigationMenuLink>
            <NavigationMenuLink href="https://kobalte.dev/docs/core/overview/animation">
              <NavigationMenuLabel>Animation</NavigationMenuLabel>
              <NavigationMenuDescription>
                Use CSS keyframes or any animation library of your choice.
              </NavigationMenuDescription>
            </NavigationMenuLink>
            <NavigationMenuLink href="https://kobalte.dev/docs/core/overview/polymorphism">
              <NavigationMenuLabel>Polymorphism</NavigationMenuLabel>
              <NavigationMenuDescription>
                Customize behavior or integrate existing libraries.
              </NavigationMenuDescription>
            </NavigationMenuLink>
            <NavigationMenuLink href="https://kobalte.dev/docs/changelog">
              <NavigationMenuLabel>Changelog</NavigationMenuLabel>
              <NavigationMenuDescription>
                Kobalte releases and their changelogs.
              </NavigationMenuDescription>
            </NavigationMenuLink>
          </NavigationMenuContent>
        </NavigationMenuItem>
 
        <NavigationMenuTrigger as="a" href="https://github.com/kobaltedev/kobalte" target="_blank">
          GitHub
        </NavigationMenuTrigger>
      </NavigationMenu>
    </div>
  )
}

export default Navbar;
