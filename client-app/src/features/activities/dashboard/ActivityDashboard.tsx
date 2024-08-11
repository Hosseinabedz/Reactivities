import React from "react";
import { Button, Grid, List } from "semantic-ui-react";
import { Activity } from "../../../app/models/activity";
import ActivityList from "./ActivityList";

interface Props {
    activities: Activity[];
}

export default function AvtivityDashboard({activities}: Props)
{
    return (
        <Grid>
            <Grid.Column width='10'>
                <ActivityList activities={activities}/>
            </Grid.Column>
        </Grid>
    )
}