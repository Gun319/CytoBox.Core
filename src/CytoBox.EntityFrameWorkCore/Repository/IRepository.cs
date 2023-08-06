using System.Linq.Expressions;

namespace CytoBox.EntityFrameWorkCore.Repository
{
    public interface IRepository : IDisposable
    {
        #region C

        /// <summary>
        /// 添加数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<bool> Create<T>(T entity) where T : class;

        /// <summary>
        /// 批量添加数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<bool> Create<T>(IEnumerable<T> entity) where T : class;

        #endregion

        #region D

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<bool> Delete<T>(T entity) where T : class;

        /// <summary>
        /// 根据查询条件删除数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        Task<bool> Delete<T>(Expression<Func<T, bool>> whereLambda) where T : class;

        #endregion

        #region U

        /// <summary>
        /// 修改数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<bool> Update<T>(T entity) where T : class;

        /// <summary>
        /// 根据条件修改数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="whereLambda"></param>
        /// <param name="updateLambda"></param>
        /// <returns></returns>
        Task<bool> Update<T>(Expression<Func<T, bool>> whereLambda, Expression<Func<T, T>> updateLambda) where T : class;

        /// <summary>
        /// 批量修改数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <returns></returns>
        Task<bool> Update<T>(IEnumerable<T> entity) where T : class;

        /// <summary>
        /// 批量统一修改数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="entity"></param>
        /// <param name="whereLambda"></param>
        /// <param name="values"></param>
        /// <returns></returns>
        Task<bool> Update<T>(T entity, Expression<Func<T, bool>> whereLambda, params string[] values) where T : class;

        #endregion

        #region R

        /// <summary>
        /// 根据主键查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="ID"></param>
        /// <returns></returns>
        Task<T> QueryByID<T>(dynamic ID) where T : class;

        /// <summary>
        /// 默认查询第一条数据，没有返回 null
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        Task<T> QueryFirstDefault<T>(Expression<Func<T, bool>>? whereLambda = null) where T : class;

        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        Task<IEnumerable<T>> QueryAll<T>() where T : class;

        /// <summary>
        /// 根据条件查询所有数据
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="whereLambda"></param>
        /// <returns></returns>
        Task<IEnumerable<T>> QueryAll<T>(Expression<Func<T, bool>>? whereLambda = null) where T : class;

        /// <summary>
        /// 获取查询数量
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="whereLamdba"></param>
        /// <returns></returns>
        Task<int> QueryCount<T>(Expression<Func<T, bool>>? whereLamdba = null) where T : class;

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="whereLamdba"></param>
        /// <returns></returns>
        Task<bool> QueryAny<T>(Expression<Func<T, bool>>? whereLamdba = null) where T : class;

        #endregion

        /// <summary>
        /// 执行原生 SQL
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sqlStr"></param>
        /// <returns></returns>
        Task<T> ExecuteSql<T>(string sqlStr) where T : class;

        /// <summary>
        /// 回滚
        /// </summary>
        /// <typeparam name="T"></typeparam>
        void RollBackChanges<T>() where T : class;
    }
}
