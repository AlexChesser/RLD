using Unity.Burst;
using Unity.Collections;
using Unity.Entities;
using Unity.Jobs;
using Unity.Mathematics;
using Unity.Transforms;

// ReSharper disable once InconsistentNaming
[UpdateInGroup(typeof(SimulationSystemGroup))]
public class PlayerSpawnSystem : JobComponentSystem
{
    BeginInitializationEntityCommandBufferSystem m_EntityCommandBufferSystem;

    protected override void OnCreate()
    {
        // Cache the BeginInitializationEntityCommandBufferSystem in a field, so we don't have to create it every frame
        m_EntityCommandBufferSystem = World.GetOrCreateSystem<BeginInitializationEntityCommandBufferSystem>();
    }

    struct SpawnJob : IJobForEachWithEntity<Player, LocalToWorld>
    {
        public EntityCommandBuffer.Concurrent CommandBuffer;

        [BurstCompile]
        public void Execute(Entity entity, int index, [ReadOnly] ref Player spawner, [ReadOnly] ref LocalToWorld location)
        {
            var instance = CommandBuffer.Instantiate(index, spawner.Prefab);
            var position = math.transform(location.Value, new float3(0, 0, 0));
            CommandBuffer.SetComponent(index, instance, new Translation { Value = position });
            //CommandBuffer.SetComponent(index, instance, new LifeTime { Value = random.NextFloat(10.0F, 100.0F) });
            //CommandBuffer.SetComponent(index, instance, new RotationSpeed_SpawnAndRemove { RadiansPerSecond = math.radians(random.NextFloat(25.0F, 90.0F)) });

            CommandBuffer.DestroyEntity(index, entity);
        }
    }

    protected override JobHandle OnUpdate(JobHandle inputDependencies)
    {
        // Schedule the job that will add Instantiate commands to the EntityCommandBuffer.
        var job = new SpawnJob
        {
            CommandBuffer = m_EntityCommandBufferSystem.CreateCommandBuffer().ToConcurrent()
        }.Schedule(this, inputDependencies);
        m_EntityCommandBufferSystem.AddJobHandleForProducer(job);

        return job;
    }
}
