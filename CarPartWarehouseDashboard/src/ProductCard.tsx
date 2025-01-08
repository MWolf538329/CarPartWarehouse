import { Component, createEffect, createSignal } from "solid-js";
import {
  Card,
  CardContent,
} from "~/components/ui/card"

interface Product {
  id: number;
  name: string;
  brand: string;
  currentStock: number;
  minStock: number;
  maxStock: number;
}

const ProductCard: Component<{ product: Product }> = props => {
  const [lowStock, setLowStock] = createSignal(false);
  createEffect(() => {
    let isLowStock = false;

    if (props.product.currentStock <= props.product.minStock) {
      isLowStock = true
    }
    else if (props.product.currentStock > props.product.minStock) {
      isLowStock = false
    }

    setLowStock(isLowStock)
  })

  return (
    <Card class={`cypressProductCard ${+ lowStock() ? "bg-red-300" : "bg-green-300"}`}>
      <CardContent>
        <p>Name: {props.product.name} - Brand: {props.product.brand} - CurrentStock: {props.product.currentStock} - MinStock: {props.product.minStock} - MaxStock: {props.product.maxStock}</p>
      </CardContent>
    </Card>
  )
}

export default ProductCard