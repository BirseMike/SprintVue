 <template>
<div class="p-grid p-fluid dashboard">
	<div class="p-col-12 p-lg-4">
		<div class="card summary">
			<span class="title">Load</span>
			<span class="detail">Number of stories in sprint</span>
			<span class="count visitors">5</span>
		</div>
	</div>
	<div class="p-col-12 p-lg-4">
		<div class="card summary">
			<span class="title">Stories In Acceptance</span>
			<span class="detail">Number of stories awaiting approval</span>
			<span class="count purchases">2</span>
		</div>
	</div>
	<div class="p-col-12 p-lg-4">
		<div class="card summary">
			<span class="title">Stories Completed</span>
			<span class="detail">No Of completed stories</span>
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
			<h1 style="font-size:16px">Recent Sales</h1>
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
                        <Button icon="pi pi-times" type="button" class="p-button-danger p-mb-1"></Button>
					</template>
				</Column>
			</DataTable>
		</div>
	</div>
	<div class="p-col-12 p-lg-6">
		<div class="card">
			<Chart type="line" :data="lineData" />
		</div>
		<div class="card">
			<Gauge type="gauge" :data="gaugeData" :options="gaugeOptions"/>
		</div>
	</div>

</div>
</template>

<script>
import SprintService from '../service/SprintService';

export default {
	data() {
		return {
			tasksCheckbox: [],
			options: {
				editable: true
			},
			events: null,
			sprintItems: null,
			selectedProducts: null,
			lineData: {
				labels: ['January', 'February', 'March', 'April', 'May', 'June', 'July'],
				datasets: [
					{
						label: 'Load',
						data: [65, 59, 80, 81, 56, 55, 40],
						fill: false,
						backgroundColor: '#2f4860',
						borderColor: '#2f4860'
					},
					{
						label: 'Burned',
						data: [28, 48, 40, 19, 86, 27, 90],
						fill: false,
						backgroundColor: '#00bb7e',
						borderColor: '#00bb7e'
					}
				]
			},
			gaugeOptions:{
                title: {
                    display: true,
                    text: 'Sprint Progress'
                   },
            },
			gaugeData:{
				datasets: [{
      value: 0.5,
      data: [2, 1],
      backgroundColor: ['green', 'orange'],
    }]
			}
		}
	},
	sprintService: null,
	created() {
		this.sprintService = new SprintService();
	},
	mounted() {
		this.sprintService.getSprintItems().then(data => this.sprintItems = data);

		let afId = this.$route.query['af_id'];
        if (afId) {
            let today = new Date();
            let expire = new Date();
            expire.setTime(today.getTime() + 3600000*24*7);
            document.cookie = 'primeaffiliateid=' + afId + ';expires=' + expire.toUTCString() + ';path=/; domain:primefaces.org';
        }
	},
	methods: {
		formatCurrency(value) {
			return value.toLocaleString('en-US', {style: 'currency', currency: 'USD'});
		}
	}
}
</script>

<style lang="scss" scoped>
	@media screen and (max-width: 960px) {
		::v-deep(.p-datatable) {
			&.p-datatable-customers {
				.p-datatable-thead > tr > th,
				.p-datatable-tfoot > tr > td {
					display: none !important;
				}

				.p-datatable-tbody > tr {
					border-bottom: 1px solid #dee2e6;
					> td {
						text-align: left;
						display: flex;
						align-items: center;
						justify-content: center;
						border: 0 none !important;
						width: 100% !important;
						float: left;
						clear: left;
						border: 0 none;

						.p-column-title {
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
