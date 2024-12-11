import { Component, createEffect, createSignal } from "solid-js";
import {
    Card,
    CardContent,
    CardDescription,
    CardFooter,
    CardHeader,
    CardTitle
  } from "~/components/ui/card"
  
  interface Stock{
    id: number;
    currentStock: number;
    min: number;
    max: number;
  }

  interface Product{
    id: number;
    name: string;
    stock: Stock;
  }

const CardComponent:Component<{product:Product}> = props => {
    let [backgroundColor, setBackgroundColor] = createSignal("#888888");
    createEffect(() => {
        if(props.product.stock.currentStock > props.product.stock.min){
            setBackgroundColor("#c8e6c9");
        }
        else if (props.product.stock.currentStock <= props.product.stock.min){
            setBackgroundColor("#ff8a80")
        }
    })    

    return (
    <Card style={{"background-color": backgroundColor()}}>
        <CardHeader>
        <CardTitle>{props.product.name}</CardTitle>
        </CardHeader>
        <CardContent>
        <p>Current: {props.product.stock.currentStock} - Min: {props.product.stock.min} - Max: {props.product.stock.max}</p>
        </CardContent>
    </Card>
    )
}

export default CardComponent