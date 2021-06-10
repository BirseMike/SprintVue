<template>
    <div class="p-grid p-fluid dashboard">
        <div class="p-col-12 p-lg-4">
            <div class="card summary">
                <span class="title">Load</span>
                <span class="detail">No of stories in sprint</span>
                <span class="count visitors">5</span>
            </div>
        </div>
        <div class="p-col-12 p-lg-4">
            <div class="card summary">
                <span class="title">Stories In Acceptance</span>
                <span class="detail">No of stories awaiting approval</span>
                <span class="count purchases">2</span>
            </div>
        </div>
        <div class="p-col-12 p-lg-4">
            <div class="card summary">
                <span class="title">Stories Completed</span>
                <span class="detail">No of completed stories</span>
                <span class="count revenue">3</span>
            </div>
        </div>

        <div class="p-col-12 p-md-6 p-xl-3">
            <div class="highlight-box">
                <div class="initials" style="background-color: #007be5; color: #00448f"><span>TV</span></div>
                <div class="highlight-details ">
                    <i class="pi pi-search"></i>
                    <span>Total Queries</span>
                    <span class="count">523</span>
                </div>
            </div>
        </div>
        <div class="p-col-12 p-md-6 p-xl-3">
            <div class="highlight-box">
                <div class="initials" style="background-color: #ef6262; color: #a83d3b"><span>TI</span></div>
                <div class="highlight-details ">
                    <i class="pi pi-question-circle"></i>
                    <span>Total Issues</span>
                    <span class="count">81</span>
                </div>
            </div>
        </div>
        <div class="p-col-12 p-md-6 p-xl-3">
            <div class="highlight-box">
                <div class="initials" style="background-color: #20d077; color: #038d4a"><span>OI</span></div>
                <div class="highlight-details ">
                    <i class="pi pi-filter"></i>
                    <span>Open Issues</span>
                    <span class="count">21</span>
                </div>
            </div>
        </div>
        <div class="p-col-12 p-md-6 p-xl-3">
            <div class="highlight-box">
                <div class="initials" style="background-color: #f9c851; color: #b58c2b"><span>CI</span></div>
                <div class="highlight-details ">
                    <i class="pi pi-check"></i>
                    <span>Closed Issues</span>
                    <span class="count">60</span>
                </div>
            </div>
        </div>
        <div class="p-col-12 p-lg-6">
            <div class="card">
                <h1 style="font-size:16px">Sprint Items</h1>
                <DataTable :value="sprintItems" class="p-datatable-customers" :rows="5" style="margin-bottom: 20px" :paginator="true">
                    <Column field="key" header="Key" :sortable="true"></Column>
                    <Column field="type" header="Type" :sortable="true"></Column>
                    <Column field="summary" header="Summary" :sortable="true"></Column>
                    <Column field="points" header="Points" :sortable="true"></Column>
                    <Column>
                        <template #header>
                            View
                        </template>
                        <template #body>
                            <Button icon="pi pi-search" type="button" class="p-button-success p-mr-2 p-mb-1"></Button>
                        </template>
                    </Column>
                </DataTable>
            </div>
        </div>
        <div class="p-col-12 p-lg-6">
            <div class="card">
                <Chart type="scatter" :data="scatterData" :options="scatterOptions" />
            </div>
            <div class="card">
                <Gauge type="gauge" :data="gaugeData" :options="gaugeOptions" />
            </div>
        </div>

    </div>
</template>

<script>
    import SprintService from '../service/SprintService';

    export default {
        data() {
            return {
                options: {
                    editable: true
                },
                sprintItems: [],
                sprints: [],
                sprintReport: { items: ["1"] },
                sprintBurnUp: { BurnPoints : [], LoadPoints:[]},
                gaugeOptions: {
                    title: {
                        display: true,
                        text: 'Sprint Progress'
                    },
                },
                scatterOptions: {
                    scales: {
                        xAxes:
                            [{
                                ticks: {
                                    userCallback: function (label) {
                                        var day = label + 1;
                                        return "Day " + day;
                                    }
                                }
                            }]
                    },
                    elements: {
                        line: {
                            tension: 0, // bezier curves,
                        }
                    }
                },
            }
        },
        sprintService: null,
        created() {
            this.sprintService = new SprintService();
        },
        mounted() {
            this.sprintService.getSprints()
                .then(data => this.sprints = data);
            this.sprintService.getSprintItems('Sprint-1')
                .then(data => this.sprintItems = data);
            this.sprintService.getSprintReport('Sprint-1')
                .then(data => this.sprintReport = data);
            this.sprintService.getSprintBurnUp('Sprint-1')
                .then(data => this.sprintBurnUp = data);

            let afId = this.$route.query['af_id'];
            if (afId) {
                let today = new Date();
                let expire = new Date();
                expire.setTime(today.getTime() + 3600000 * 24 * 7);
                document.cookie = 'primeaffiliateid=' + afId + ';expires=' + expire.toUTCString() + ';path=/; domain:primefaces.org';
            }
        },
        computed: {
            gaugeData: function () {
                // `this` points to the vm instance
                return {
                    datasets: [{
                        value: 2.5,
                        data: [Object.keys(this.sprintReport.items).length, Object.keys(this.sprintReport.items).length-5],
                        backgroundColor: ['green', 'orange'],
                    }]
                }
            },
            scatterData: function () {
                return {
                    datasets: [{
                        label: "Load",
                        borderColor: "green",
                        borderWidth: 2,
                        showLine: true,
                        fill: false,
                        data: this.sprintBurnUp.loadPoints
                    },
                    {
                        label: "Burn Up",
                        borderColor: "red",
                        borderWidth: 2,
                        showLine: true,
                        fill: false,
                        data: this.sprintBurnUp.burnPoints
                    }]

                }
            }
        },
        methods: {
            formatCurrency(value) {
                return value.toLocaleString('en-US', { style: 'currency', currency: 'USD' });
            }
        }
    }
</script>

<style lang="scss" scoped>
    @media screen and (max-width: 960px) {
        ::v-deep(.p-datatable) {
            &.p-datatable-customers

    {
        .p-datatable-thead > tr > th, .p-datatable-tfoot > tr > td

    {
        display: none !important;
    }

    .p-datatable-tbody > tr {
        border-bottom: 1px solid #dee2e6;
        > td

    {
        text-align: left;
        display: flex;
        align-items: center;
        justify-content: center;
        border: 0 none !important;
        width: 100% !important;
        float: left;
        clear: left;
        border: 0 none;
        .p-column-title

    {
        padding: .4rem;
        min-width: 30%;
        display: inline-block;
        margin: -.4rem 1rem -.4rem -.4rem;
        font-weight: bold;
    }

    .p-progressbar {
        margin-top: .5rem;
    }

    }
    }
    }
    }
    }
</style>
