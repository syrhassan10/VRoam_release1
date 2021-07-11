#include "pch-c.h"
#ifndef _MSC_VER
# include <alloca.h>
#else
# include <malloc.h>
#endif


#include "codegen/il2cpp-codegen-metadata.h"





// 0x00000001 System.Void EdgeER::.ctor(PointER,PointER)
extern void EdgeER__ctor_m759F0B44099A7E5E0DE75758BD246EEF65C968D0 (void);
// 0x00000002 System.Int32 EdgeER::GetHashCode()
extern void EdgeER_GetHashCode_m6CA1510644AB77F0B2717997DAF342BAA7CC41A8 (void);
// 0x00000003 System.Boolean EdgeER::Equals(System.Object)
extern void EdgeER_Equals_m038D0159B9A78667A9B75C62BEB4383D1B36EE7E (void);
// 0x00000004 System.Boolean EdgeER::op_Equality(EdgeER,EdgeER)
extern void EdgeER_op_Equality_mCCC1A96F86F1B4C05C9054AAFFF1881F40140D47 (void);
// 0x00000005 System.Void PointER::.ctor(System.Single,System.Single,System.Single)
extern void PointER__ctor_m426D2B346CFEC151CD61678D909F90ADD90B9650 (void);
// 0x00000006 System.Int32 PointER::GetHashCode()
extern void PointER_GetHashCode_mC63C2DACC5B94EB37EFC6D8ADC506B8394C37A34 (void);
// 0x00000007 System.Boolean PointER::Equals(System.Object)
extern void PointER_Equals_m60262FA9AB6436BAF845B269E61241C43798431A (void);
// 0x00000008 System.Boolean PointER::op_Equality(PointER,PointER)
extern void PointER_op_Equality_mD680E06FE439816EAE2EC171D94670BEA818BCDB (void);
// 0x00000009 System.Int32 delaunayER::FindVertice(UnityEngine.Vector3,System.Collections.Generic.List`1<UnityEngine.Vector3>)
extern void delaunayER_FindVertice_m4EB2EC398C9F68748AAEB5989B343D4378DA1160 (void);
// 0x0000000A System.Collections.Generic.List`1<TriangleER> delaunayER::Triangulate(System.Collections.Generic.List`1<PointER>)
extern void delaunayER_Triangulate_m8DED5B32419B6950EB8E16C1D7686AAC87253574 (void);
// 0x0000000B TriangleER delaunayER::SuperTriangle(System.Collections.Generic.List`1<PointER>)
extern void delaunayER_SuperTriangle_mFA4457C74B1C6D4D1468DEA2074A3F9A6669FD37 (void);
// 0x0000000C System.Void TriangleER::.ctor(PointER,PointER,PointER)
extern void TriangleER__ctor_mD96FA7365F7216A98FABE8A22D9789520761F144 (void);
// 0x0000000D System.Double TriangleER::ContainsInCircumcircle(PointER)
extern void TriangleER_ContainsInCircumcircle_m6F690227E9E046B5AD765F8C7A05A0802EE0FB85 (void);
// 0x0000000E System.Boolean TriangleER::SharesVertexWith(TriangleER)
extern void TriangleER_SharesVertexWith_m9533A722EE0AE361839206315AF1D3C988766623 (void);
static Il2CppMethodPointer s_methodPointers[14] = 
{
	EdgeER__ctor_m759F0B44099A7E5E0DE75758BD246EEF65C968D0,
	EdgeER_GetHashCode_m6CA1510644AB77F0B2717997DAF342BAA7CC41A8,
	EdgeER_Equals_m038D0159B9A78667A9B75C62BEB4383D1B36EE7E,
	EdgeER_op_Equality_mCCC1A96F86F1B4C05C9054AAFFF1881F40140D47,
	PointER__ctor_m426D2B346CFEC151CD61678D909F90ADD90B9650,
	PointER_GetHashCode_mC63C2DACC5B94EB37EFC6D8ADC506B8394C37A34,
	PointER_Equals_m60262FA9AB6436BAF845B269E61241C43798431A,
	PointER_op_Equality_mD680E06FE439816EAE2EC171D94670BEA818BCDB,
	delaunayER_FindVertice_m4EB2EC398C9F68748AAEB5989B343D4378DA1160,
	delaunayER_Triangulate_m8DED5B32419B6950EB8E16C1D7686AAC87253574,
	delaunayER_SuperTriangle_mFA4457C74B1C6D4D1468DEA2074A3F9A6669FD37,
	TriangleER__ctor_mD96FA7365F7216A98FABE8A22D9789520761F144,
	TriangleER_ContainsInCircumcircle_m6F690227E9E046B5AD765F8C7A05A0802EE0FB85,
	TriangleER_SharesVertexWith_m9533A722EE0AE361839206315AF1D3C988766623,
};
static const int32_t s_InvokerIndices[14] = 
{
	1280,
	2454,
	1835,
	3752,
	841,
	2454,
	1835,
	3752,
	3640,
	3984,
	3984,
	804,
	1429,
	1835,
};
extern const CustomAttributesCacheGenerator g_DelaunayER_AttributeGenerators[];
IL2CPP_EXTERN_C const Il2CppCodeGenModule g_DelaunayER_CodeGenModule;
const Il2CppCodeGenModule g_DelaunayER_CodeGenModule = 
{
	"DelaunayER.dll",
	14,
	s_methodPointers,
	0,
	NULL,
	s_InvokerIndices,
	0,
	NULL,
	0,
	NULL,
	0,
	NULL,
	NULL,
	g_DelaunayER_AttributeGenerators,
	NULL, // module initializer,
	NULL,
	NULL,
	NULL,
};
