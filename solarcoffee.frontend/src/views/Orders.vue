<template>
    <div>
        <h1 id="ordersTitle">
            Sales Orders
        </h1>
        <hr/>
        <table id="sales-orders" class="table" v-if="orders.length">
            <thead>
                <tr>
                    <th>CustomerId</th>
                    <th>OrderId</th>
                    <th>Order Total</th>
                    <th>Order Status</th>
                    <th>Mark Complete</th>
                </tr>
                <tr v-for="order in orders" :key="order.id">
                    <td>
                        {{order.customer.id}}
                    </td>
                    <td>
                        {{order.id}}
                    </td>
                    <td>
                        {{getTotal(order) | price}}
                    </td>
                    <td :class="{green : order.isPaid}">
                        {{getStatus(order.isPaid)}}
                    </td>
                    <td>
                        <div 
                        v-if="!order.isPaid" 
                        class="lni lni-checkmark-circle order-complete green"
                        @click="markComplete(order.id)"></div>
                    </td>
                </tr>
            </thead>
        </table>
    </div>
</template>

<script lang="ts">
import {Component, Vue} from 'vue-property-decorator';
import OrderService from '@/services/order-service';
import {ISalesOrder} from '@/types/SalesOrder';

const orderService = new OrderService();

@Component({
    name: 'Orders'
})
 export default class Orders extends Vue{
    orders: ISalesOrder[] = [];

    getTotal(order: ISalesOrder){
      //reduce function with acumulator a, and current value b
      return order.salesOrderItems.reduce((a, b)=> a + (b['product']['price'] * b['quantity']), 0);
    }

    getStatus(isPaid: boolean){
        return isPaid ? "Paid in Full" : "Unpaid";
    }

    async markComplete(orderId: number){
        await orderService.makeOrderComplete(orderId);
        this.fetchData();
    }

    async fetchData(){
        this.orders = await orderService.getOrders();
    }

    created(){
        this.fetchData();
    }
 }

</script>

<style lang="scss" scoped>
@import "@/scss/global.scss";
.green{
    font-weight: bold;
    color: $solar-green;
}

.order-complete{
    cursor: pointer;
    text-align: center;
}

</style>